# Software Engineer

## Introduction
This reposiory is built base on

- Subject: **Software Engineer** 
- Faculty: [Faculty of Information Technology](https://it.tdtu.edu.vn/)
- University: [Ton Duc Thang University](https://tdtu.edu.vn/)

## Document
[SE Docs](https://drive.google.com/drive/folders/12VqMEkfvl8zp-Ir3XfXuEBxgR2DuvVzj?usp=sharing)

## Final project includes
  - Design files
  - Source
  - Report
  - Powerpoint
  - Contribute

## Demo

[View at youtube for higher quality](https://youtu.be/rDrFv5Zcxuc)

https://github.com/maoleng/software-engineer/assets/91431461/0184633a-0fc2-47af-a8eb-78f3c655ead3

## How to run project
- Webform (.NET Winform)
	- Import the database
	- Config the database connection string in Web.config
	If you can not do with connection string
	- Delete the tag <connectionStrings> in Web.config
	- Delete all files in folder Models
	- Right click on folder Models, choose Add -> New item, choose ADO.NET Entity Data Model, edit the name from Model1 to Model then add following the IDE, renember the entity name is SoftwareEngineerEntities
	- F5 to run

- Winform (ASP .NET MVC)
	- Import the database
	- Config the database connection string in App.config
	If you can not do with connection string
	- Delete the tag <connectionStrings> in App.config
	- Delete all files of Model.edmx
	- Right click on folder Project name, choose Add -> New item, choose ADO.NET Entity Data Model, edit the name from Model1 to Model then add following the IDE, renember the entity name is SoftwareEngineerEntities
	- F5 to run

- B2C (PHP Laravel)
	- Import database
	- Config database in file .env 
	- Run this command at the root of Web folder to install package of laravel
		```composer update```
	- Run this command at the root of B2C folder to open a server
		```php artisan serve```

## FIGMA
- [WinForm](https://www.figma.com/file/gbEc1p1cigiKo3fpM2OehU/Winform?type=design&node-id=0%3A1&t=ZXlSh0uK4maxKfXO-1)
- [WebForm](https://www.figma.com/file/xJRFdMur1G126Id49TJ7NA/Webform?type=design&node-id=0%3A1&t=8sFwgjDm3fGpBOHM-1)
- [Web B2C](https://www.figma.com/file/3vdVuHF5sbTe6JF0Duck1L/Web-B2C?type=design&node-id=0%3A1&t=QYfY583NAJtKZ01l-1)
