IF EXISTS (SELECT * FROM sysobjects WHERE name = 'fk_products_suppliers')
BEGIN
  ALTER TABLE dbo.products
  DROP CONSTRAINT fk_products_suppliers
END;

IF EXISTS (SELECT * FROM sysobjects WHERE name = 'fk_product_categories_products')
BEGIN
  ALTER TABLE dbo.product_categories
  DROP CONSTRAINT fk_product_categories_products
END;

IF EXISTS (SELECT * FROM sysobjects WHERE name = 'fk_product_categories_suppliers')
BEGIN
  ALTER TABLE dbo.product_categories
  DROP CONSTRAINT fk_product_categories_suppliers
END;

IF EXISTS (SELECT * FROM sysobjects WHERE name = 'fk_carts_users')
BEGIN
  ALTER TABLE dbo.carts
  DROP CONSTRAINT fk_carts_users
END;

IF EXISTS (SELECT * FROM sysobjects WHERE name = 'fk_orders_users')
BEGIN
  ALTER TABLE dbo.orders
  DROP CONSTRAINT fk_orders_users
END;

DROP TABLE IF EXISTS users;
DROP TABLE IF EXISTS carts;
DROP TABLE IF EXISTS orders;
DROP TABLE IF EXISTS suppliers;
DROP TABLE IF EXISTS categories;
DROP TABLE IF EXISTS products;
DROP TABLE IF EXISTS product_categories;

CREATE TABLE suppliers (
	id int IDENTITY PRIMARY KEY,
	supplier_name VARCHAR(20),
	supplier_description VARCHAR(100));

CREATE TABLE categories (
	id int IDENTITY PRIMARY KEY,
	category_name VARCHAR (60),
	category_description VARCHAR (60),
	department VARCHAR (60));

CREATE TABLE products (
	id int IDENTITY PRIMARY KEY,
	product_name VARCHAR(60),
	product_descritpion VARCHAR(100),
	price DECIMAL,
	image_name VARCHAR(60),
	currency VARCHAR(60),
	supplier_id int);

CREATE TABLE product_categories (
	id int IDENTITY PRIMARY KEY,
	product_id int,
	category_id int);

CREATE TABLE users (
	id int IDENTITY PRIMARY KEY,
	first_name VARCHAR(60),
	last_name VARCHAR(60),
	email VARCHAR(60),
	user_password VARCHAR(60));

CREATE TABLE carts (
	id int IDENTITY PRIMARY KEY,
	products VARCHAR(60),
	userId int);

CREATE TABLE orders (
	id int IDENTITY PRIMARY KEY,
	order_status VARCHAR(60),
	products VARCHAR(60),
	order_date DATE,
	total_price DECIMAL,
	userId int);

ALTER TABLE products
	ADD CONSTRAINT fk_products_suppliers FOREIGN KEY (supplier_id) REFERENCES suppliers(id) ON DELETE CASCADE;

ALTER TABLE product_categories
	ADD CONSTRAINT fk_product_categories_products FOREIGN KEY (product_id) REFERENCES products(id) ON DELETE CASCADE;

ALTER TABLE product_categories
	ADD CONSTRAINT fk_product_categories_suppliers FOREIGN KEY (category_id) REFERENCES categories(id) ON DELETE CASCADE;

ALTER TABLE carts
	ADD CONSTRAINT fk_carts_users FOREIGN KEY (userId) REFERENCES users(id) ON DELETE CASCADE;

ALTER TABLE orders
	ADD CONSTRAINT fk_orders_users FOREIGN KEY (userId) REFERENCES users(id) ON DELETE CASCADE;

INSERT INTO suppliers (
	supplier_name,
	supplier_description)
VALUES 
	('UAC', 'The number 1 megacorporation'),
	('Kalashnikov', 'Russian engineering at its best'),
	('Black Market', 'No questions asked'),
	('Colt', 'America... fuck yeah!');

INSERT INTO products (
	product_name,
	product_descritpion,
	price,
	image_name,
	currency,
	supplier_id)
VALUES
	('BFG', 'Clears your view of anything and everything.', 666000.0, 'BFG', 'USD', 1),
	('AK-47', 'For those old-school guys who just love classics.', 52999.0, 'AK-47', 'USD', 2),
	('Tactical Nuke', 'Try throwing it from very far away. Launcher sold separately.', 1500.0, 'Tactical Nuke', 'USD', 3),
	('Sea Mine', 'Calm your seas to calm your soul.', 145000.0, 'Sea Mine', 'USD', 3),
	('Flamethrower', 'Light up the room with your new gear. Gasoline sold separately.', 10000.0, 'Flamethrower', 'USD', 3),
	('Colt Python', 'For everything above C-level.', 1000.0, 'Colt Python', 'USD', 4);

INSERT INTO categories (
	category_name,
	category_description,
	department)
VALUES
	('Futuristic', 'Gun', 'Cutting edge technology'),
	('Assault Rifle', 'Gun', 'Cutting edge technology, but faster'),
	('Not Geneva Compatible', 'Banned', 'Fun, but maybe not for everyone'),
	('Bomb', 'Explosives', 'For explosive finishes'),
	('Handgun', 'Gub', 'Travellers favourite');

INSERT INTO product_categories (
	product_id,
	category_id)
VALUES
	(1, 1),
	(2, 2),
	(3, 3),
	(4, 3),
	(5, 3),
	(6, 4);