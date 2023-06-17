create database pos;
go
use pos;
go


create table tblusers (
    id int primary key identity ,
	fullname varchar(100) null,
	email varchar(100) null,
	phone varchar(12) null,
	password text,
	role_id int default(0) 
);

create table tblunits (
	id int primary key identity,
	unit varchar(50),
	description varchar(100) null
);

create table tblbrands (
	id int primary key identity,
	brand varchar(50),
	description varchar(100) null
);

create table tblcategories (
	id int primary key identity,
	category varchar(50),
	description varchar(100) null
);


create table tblproducts (
	id int primary key identity,
	name varchar(100),
	unit_price int,
	category_id int,
	brand_id int,
	unit_id int,
	note varchar(100) null,

	FOREIGN KEY (category_id) REFERENCES tblcategories(id) ON DELETE CASCADE ON update CASCADE ,
	FOREIGN KEY (brand_id) REFERENCES tblbrands(id) ON DELETE CASCADE ON update CASCADE ,
	FOREIGN KEY (brand_id) REFERENCES tblunits(id) ON DELETE CASCADE ON update CASCADE 
     
      
);



create table tblvenders(
	id int primary key identity,
	fullname varchar(100),
	email varchar(100) null,
	phone varchar(100) null,
	adress varchar(100) null,
	note varchar(100) null,
);

create table tblcustomers(
	id int primary key identity,
	fullname varchar(100),
	email varchar(100) null,
	phone varchar(100) null,
	adress varchar(100) null,
	note varchar(100) null,
);


create table tblinventory(
	id int primary key identity,
	product_id int ,
	Purchases_id int null,
	stockin_qty int null, 
	sale_qty int null,
	buy_price float null,
	sale_price float null,
	date date null,
	FOREIGN KEY (product_id) REFERENCES tblproducts(id) ON DELETE CASCADE ON update CASCADE ,
);


create table tblstockin(
	id int primary key identity,
	Purchases_id int ,
	total float,
	vat float default(0) null,
	discount float default(0) null,
	free_qty int default(0) null,
	total_amount float default(0) null,
	date date null,
	isreturn int null,
	returnreson varchar(100) null,
	
	
);

create table tblstockin_detail(
	id int primary key identity,
	Purchases_id int ,
	
	product_id int ,
	discount float default(0) null,
	free_qty int default(0) null,
	total_amount float default(0) null,
	date date null,
	isreturn int null,
	returnreson varchar(100) null,
	return_qty int null,
	FOREIGN KEY (product_id) REFERENCES tblproducts(id) ON DELETE CASCADE ON update CASCADE ,
	

);


create table tblsale(
	id int primary key identity,
	sale_id int ,
	sale_date date null,
	total float,
	vat float default(0) null,
	discount float default(0) null,
	free_qty int default(0) null,
	total_amount float default(0) null,
	isreturn int null,
	returnreson varchar(100) null
	
);


create table tblsale_details(
	id int primary key identity,
	product_id int ,
	sale_id int ,
	sale_date date null,
	total float,
	vat float default(0) null,
	discount float default(0) null,
	free_qty int default(0) null,
	total_amount float default(0) null,
	isreturn int null,
	returnreson varchar(100) null,
	return_qty int null,

	FOREIGN KEY (product_id) REFERENCES tblproducts(id) ON DELETE CASCADE ON update CASCADE ,
);


