USE Arquisoft;
GO
--IF EXISTS (SELECT * FROM Users WHERE Name = 'Admin')
BEGIN
-- Carga de provincias
-- Falta Caba y/ capital federal
INSERT INTO Provinces (Description)
VALUES
    ('Buenos Aires'),
    ('Catamarca'),
    ('Chaco'),
    ('Chubut'),
    ('C�rdoba'),
    ('Corrientes'),
    ('Entre R�os'),
    ('Formosa'),
    ('Jujuy'),
    ('La Pampa'),
    ('La Rioja'),
    ('Mendoza'),
    ('Misiones'),
    ('Neuqu�n'),
    ('R�o Negro'),
    ('Salta'),
    ('San Juan'),
    ('San Luis'),
    ('Santa Cruz'),
    ('Santa Fe'),
    ('Santiago del Estero'),
    ('Tierra del Fuego'),
    ('Tucum�n');

	INSERT INTO [dbo].[UserRoles] ([Description])
VALUES
    ('Admin'),
    ('Usuario'),
    ('Soporte'),
	('T�cnico'),
	('Visitante');

INSERT INTO [dbo].[ProjectState] ([Description])
VALUES
   ('Activo'),
    ('Inactivo'),
	('En progreso'),
	('Completado'),
	('Pendiente');
	

INSERT INTO [dbo].[UserStates] ([Description])
VALUES
    ('Activo'),
    ('Inactivo');

INSERT INTO [dbo].[ClientStates] ([Description])
VALUES
    ('Activo'),
    ('Inactivo');

INSERT INTO ClientRoles (Description)
VALUES
    ('Cliente');


--Crear Tipo de Proyectos
INSERT ServiceTypes (ServiceTypeName,ServiceTypeDescription)
VALUES('Se trabajar� en el completamiento del anteproyecto, desarrollando el material necesario para la ejecuci�n en obra. En esta etapa deber� recurrirse al trabajo interdisciplinar, para el estudio de suelo y el c�lculo estructural (cimientos, vigas, columnas, losas, etc).
Todo encuadrado en las normativas vigentes.
Tiempo de trabajo aproximado:
Entre 1 y 3 meses (dependiendo de la complejidad de proyecto, necesidad de investigaci�n y b�squeda, definici�n de cliente)
Material a entregar:
Confecci�n de plano municipal
Presentaci�n de planos para la realizaci�n de tr�mites correspondientes
Dise�o de mobiliario escala 1:20
Planilla de aberturas
Planos de estructuras
Detalles constructivos
Planos de instalaciones (sanitario-agua-gas-electricidad-pluvial)
C�mputo m�trico (c�lculo estimativo de materiales y artefactos a comprar, previo asesoramiento
y selecci�n de los mismos)
Asesoramiento/an�lisis de costo/an�lisis de factibilidad','Proyecto con detalle')

INSERT ServiceTypes(ServiceTypeName,ServiceTypeDescription)
VALUES('Control de obra
Planificaci�n de obra (secuencia l�gica de ejecuci�n de cada actividad o rubro)
Programaci�n de obra (Estimaci�n de tiempo para ejecutar cada actividad y rendimiento)
Tiempo de trabajo aproximado:
Duraci�n de la obra, segun la planificaci�n
Material a entregar:
Certificaciones de avance de obra cada 15 d�as','Conducci�n T�cnica')

INSERT ServiceTypes(ServiceTypeName,ServiceTypeDescription)
VALUES('Se trabajar� con la IDEA DE PROYECTO, atendiendo a la situaci�n particular del cliente seg�n la informaci�n brindada por el mismo (necesidades, deseos, recursos disponibles, lote, orientaciones, implantaci�n, programa, usuario) Se escucha del cliente, se capta y procesa la informaci�n, estudian y analizan todas estas variables, brindando asesoramiento profesional y personalizado, determinando las mejores alernativas para llevar a cabo el encargo, seg�n cada caso en particular..
Todo encuadrado en  el conocimiento y aplicaci�n las normativas vigentes.
Tiempo de trabajo aproximado:
Entre 1 y 3 meses (dependiendo de la complejidad de proyecto, necesidad de investigaci�n y b�squeda, definici�n de cliente)
Material a entregar:
-Memoria descriptiva del proyecto
-Plantas (Escala1:100)
-Cortes (Escala1:100)
-Vistas (Escala1:100)
-Esquema de planteo estructural
-Renders (cantidad a definir seg�n necesidad)
-Esquemas explicativos, axonometricas, y otros recursos gr�ficos a convenir seg�n cada caso, necesarios para TRANSMITIR Y PLASMAR las ideas de proyecto','Anteproyecto')



	-- Provincia de Buenos Aires
INSERT INTO Localities (ProvinceId, Description)
VALUES
    (1, 'Buenos Aires'),
    (1, 'La Plata'),
    (1, 'Mar del Plata'),
    (1, 'Bah�a Blanca'),
    (1, 'San Isidro'),
    (1, 'Pilar'),
    (1, 'Quilmes'),
    (1, 'Mor�n'),
    (1, 'Tandil'),
    (1, 'Lomas de Zamora');

-- Provincia de Catamarca
INSERT INTO Localities(ProvinceId, Description)
VALUES
    (2, 'San Fernando del Valle de Catamarca'),
    (2, 'Andalgal�'),
    (2, 'Bel�n'),
    (2, 'Santa Mar�a'),
    (2, 'Recreo'),
    (2, 'Fiambal�'),
    (2, 'Tinogasta'),
    (2, 'Saujil'),
    (2, 'Aconquija'),
    (2, 'Los Altos');

-- Provincia de Chaco
INSERT INTO Localities (ProvinceId, Description)
VALUES
    (3, 'Resistencia'),
    (3, 'Barranqueras'),
    (3, 'Fontana'),
    (3, 'Presidencia Roque S�enz Pe�a'),
    (3, 'Villa �ngela'),
    (3, 'Charata'),
    (3, 'General San Mart�n'),
    (3, 'Juan Jos� Castelli'),
    (3, 'Quitilipi'),
    (3, 'Machagai');

-- Provincia de Chubut
INSERT INTO Localities (ProvinceId, Description)
VALUES
    (4, 'Rawson'),
    (4, 'Comodoro Rivadavia'),
    (4, 'Puerto Madryn'),
    (4, 'Trelew'),
    (4, 'Esquel'),
    (4, 'Rada Tilly'),
    (4, 'Gaiman'),
    (4, 'Sarmiento'),
    (4, 'Dolavon'),
    (4, 'Gobernador Costa');

-- Provincia de C�rdoba
INSERT INTO Localities (ProvinceId, Description)
VALUES
    (5, 'C�rdoba'),
    (5, 'Villa Carlos Paz'),
    (5, 'R�o Cuarto'),
    (5, 'Alta Gracia'),
    (5, 'San Francisco'),
    (5, 'Villa Mar�a'),
    (5, 'Jes�s Mar�a'),
    (5, 'Bell Ville'),
    (5, 'Cosqu�n'),
    (5, 'La Falda');

-- Provincia de Corrientes
INSERT INTO Localities (ProvinceId, Description)
VALUES
    (6, 'Corrientes'),
    (6, 'Goya'),
    (6, 'Mercedes'),
    (6, 'Curuz� Cuati�'),
    (6, 'Bella Vista'),
    (6, 'Esquina'),
    (6, 'Ituzaing�'),
    (6, 'Santo Tom�'),
    (6, 'Monte Caseros'),
    (6, 'Paso de los Libres');

-- Provincia de Entre R�os
INSERT INTO Localities (ProvinceId, Description)
VALUES
    (7, 'Paran�'),
    (7, 'Concordia'),
    (7, 'Gualeguaych�'),
    (7, 'Gualeguay'),
    (7, 'Chajar�'),
    (7, 'Villaguay'),
    (7, 'Col�n'),
    (7, 'Victoria'),
    (7, 'Diamante'),
    (7, 'La Paz');

-- Provincia de Formosa
INSERT INTO Localities (ProvinceId, Description)
VALUES
    (8, 'Formosa'),
    (8, 'Clorinda'),
    (8, 'Piran�'),
    (8, 'El Colorado'),
    (8, 'Las Lomitas'),
    (8, 'Riacho He H�'),
    (8, 'Laguna Yema'),
    (8, 'Ibarreta'),
    (8, 'General G�emes'),
    (8, 'San Mart�n 2');

-- Provincia de Jujuy
INSERT INTO Localities (ProvinceId, Description)
VALUES
    (9, 'San Salvador de Jujuy'),
    (9, 'Palpal�'),
    (9, 'San Pedro'),
    (9, 'Libertador General San Mart�n'),
    (9, 'Perico'),
    (9, 'El Carmen'),
    (9, 'Humahuaca'),
    (9, 'La Quiaca'),
    (9, 'Tilcara'),
    (9, 'Abra Pampa');

-- Provincia de La Pampa
INSERT INTO Localities (ProvinceId, Description)
VALUES
    (10, 'Santa Rosa'),
    (10, 'General Pico'),
    (10, 'Toay'),
    (10, 'Realic�'),
    (10, 'Eduardo Castex'),
    (10, 'General Acha'),
    (10, '25 de Mayo'),
    (10, 'General Manuel J. Campos'),
    (10, 'Catril�'),
    (10, 'Macach�n');

-- Provincia de La Rioja
INSERT INTO Localities (ProvinceId, Description)
VALUES
    (11, 'La Rioja'),
    (11, 'Chilecito'),
    (11, 'Chamical'),
    (11, 'Famatina'),
    (11, 'Chepes'),
    (11, 'Arauco'),
    (11, 'Olta'),
    (11, 'Villa Uni�n'),
    (11, 'Villa Castelli'),
    (11, 'Sanagasta');

-- Provincia de Mendoza
INSERT INTO Localities (ProvinceId, Description)
VALUES
    (12, 'Mendoza'),
    (12, 'San Rafael'),
    (12, 'Godoy Cruz'),
    (12, 'Luj�n de Cuyo'),
    (12, 'Las Heras'),
    (12, 'Maip�'),
    (12, 'San Mart�n'),
    (12, 'Malarg�e'),
    (12, 'Tunuy�n'),
    (12, 'General Alvear');

-- Provincia de Misiones
INSERT INTO Localities (ProvinceId, Description)
VALUES
    (13, 'Posadas'),
    (13, 'Eldorado'),
    (13, 'Puerto Iguaz�'),
    (13, 'Ober�'),
    (13, 'Apostoles'),
    (13, 'San Vicente'),
    (13, 'Alem'),
    (13, 'Jard�n Am�rica'),
    (13, 'Montecarlo'),
    (13, 'Puerto Rico');

-- Provincia de Neuqu�n
INSERT INTO Localities (ProvinceId, Description)
VALUES
    (14, 'Neuqu�n'),
    (14, 'San Mart�n de los Andes'),
    (14, 'Cutral C�'),
    (14, 'Plottier'),
    (14, 'Zapala'),
    (14, 'Centenario'),
    (14, 'Villa La Angostura'),
    (14, 'Chos Malal'),
    (14, 'Senillosa'),
    (14, 'Rinc�n de los Sauces');

-- Provincia de R�o Negro
INSERT INTO Localities (ProvinceId, Description)
VALUES
    (15, 'Viedma'),
    (15, 'San Carlos de Bariloche'),
    (15, 'General Roca'),
    (15, 'Cipolletti'),
    (15, 'Allen'),
    (15, 'El Bols�n'),
    (15, 'Ingeniero Jacobacci'),
    (15, 'Villa Regina'),
    (15, 'Choele Choel'),
    (15, 'Cinco Saltos');

-- Provincia de Salta
INSERT INTO Localities (ProvinceId, Description)
VALUES
    (16, 'Salta'),
    (16, 'San Ram�n de la Nueva Or�n'),
    (16, 'General G�emes'),
    (16, 'Tartagal'),
    (16, 'Cafayate'),
    (16, 'San Pedro de Jujuy'),
    (16, 'Met�n'),
    (16, 'El Carril'),
    (16, 'Rosario de la Frontera'),
    (16, 'Chicoana');

-- Provincia de San Juan
INSERT INTO Localities (ProvinceId, Description)
VALUES
    (17, 'San Juan'),
    (17, 'Rawson'),
    (17, 'Chimbas'),
    (17, 'Pocito'),
    (17, 'Rivadavia'),
    (17, 'Santa Luc�a'),
    (17, 'Caucete'),
    (17, 'Albard�n'),
    (17, 'J�chal'),
    (17, '25 de Mayo');

-- Provincia de San Luis
INSERT INTO Localities (ProvinceId, Description)
VALUES
    (18, 'San Luis'),
    (18, 'Villa Mercedes'),
    (18, 'San Francisco del Monte de Oro'),
    (18, 'La Toma'),
    (18, 'Justo Daract'),
    (18, 'Merlo'),
    (18, 'Santa Rosa del Conlara'),
    (18, 'Naschel'),
    (18, 'Quines'),
    (18, 'Concar�n');

-- Provincia de Santa Cruz
INSERT INTO Localities (ProvinceId, Description)
VALUES
    (19, 'R�o Gallegos'),
    (19, 'Caleta Olivia'),
    (19, 'El Calafate'),
    (19, 'Puerto Deseado'),
    (19, 'R�o Turbio'),
    (19, '28 de Noviembre'),
    (19, 'Pico Truncado'),
    (19, 'Las Heras'),
    (19, 'Perito Moreno'),
    (19, 'Gobernador Gregores');

-- Provincia de Santa Fe
INSERT INTO Localities (ProvinceId, Description)
VALUES
    (20, 'Santa Fe'),
    (20, 'Rosario'),
    (20, 'Venado Tuerto'),
    (20, 'Rafaela'),
    (20, 'Reconquista'),
    (20, 'Santo Tom�'),
    (20, 'Constituci�n'),
    (20, 'San Lorenzo'),
    (20, 'Granadero Baigorria'),
    (20, 'Firmat');

-- Provincia de Santiago del Estero
INSERT INTO Localities (ProvinceId, Description)
VALUES
    (21, 'Santiago del Estero'),
    (21, 'La Banda'),
    (21, 'Termas de R�o Hondo'),
    (21, 'A�atuya'),
    (21, 'Fern�ndez'),
    (21, 'Clodomira'),
    (21, 'Fr�as'),
    (21, 'Loreto'),
    (21, 'Suncho Corral'),
    (21, 'Beltr�n');

-- Provincia de Tierra del Fuego, Ant�rtida e Islas del Atl�ntico Sur
INSERT INTO Localities (ProvinceId, Description)
VALUES
    (22, 'Ushuaia'),
    (22, 'R�o Grande'),
    (22, 'Tolhuin'),
    (22, 'Puerto Almanza'),
    (22, 'San Juli�n'),
    (22, 'Puerto Williams'),
    (22, 'Puerto Toro'),
    (22, 'Puerto Yartou'),
    (22, 'Caleta Mar�a'),
    (22, 'Puerto Roballo');

-- Provincia de Tucum�n
INSERT INTO Localities (ProvinceId, Description)
VALUES
    (23, 'San Miguel de Tucum�n'),
    (23, 'Yerba Buena'),
    (23, 'Banda del R�o Sal�'),
    (23, 'Concepci�n'),
    (23, 'Aguilares'),
    (23, 'Taf� Viejo'),
    (23, 'Famaill�'),
    (23, 'Taf� del Valle'),
    (23, 'Monteros'),
    (23, 'Lules');

--Crear Cliente TEST
INSERT INTO Addresses (AddressLine, PostalCode, Numbering, Department, Floor, Neighborhood, ProvinceId, LocalityId, AdditionalInstructions)
            VALUES ('Boyero', 5000, 528, 1, 1, 'Chateau Carreras', 5, 3, NULL),
			('Cerrito', 5000, 173, 1, 1, 'Arguello', 5, 3, NULL),
			('Chancay', 5003, 1401, 1, 1, 'Observatorio', 5, 2, NULL),
			('San Mart�n', 5000, 867, 1, 1, 'San Vicente', 7, 5, NULL),
			('9 de Julio', 5010, 422, 1, 1, 'San Mart�n', 8, 4, NULL),
			('25 de Mayo', 5800, 8, 1, 1, '9 de Julio', 3, 3, NULL),
			('Rosario', 5125, 914, 1, 1, 'Bella Vista', 2, 4, NULL),
			('Colon', 4052, 777, 1, 1, 'Quintana', 1, 3, NULL),
			('Salta', 3582, 1522, 1, 1, 'Belgrano', 1, 2, NULL),
			('Jujuy', 5008, 4006, 1, 1, 'Palermo', 9, 1, NULL);

		
			
INSERT INTO Clients (Name, LastName, Password, DocumentNumber, Mail, Telephone, ClientStateId, ClientRoleId, PreferencesId, AddressId)
            VALUES ('Marcos', 'Mateos', 1234, 38474256, 'marcosmateos@gmail.com', 3551122334, 1, 1, 1, 1),
    ('Juan', 'G�mez', 1234, 47768238, 'juangomez@gmail.com', 3998877665, 1, 1, 1, 2),
    ('Luisa', 'S�nchez', 1234, 22349641, 'luisasanchez@gmail.com', 3889998877, 1, 1, 1, 3),
    ('Andr�s', 'P�rez', 1234, 44000670, 'andresperez@gmail.com', 3776665544, 1, 1, 1, 4),
    ('Carolina', 'L�pez', 1234, 15487263, 'carolinalopez@gmail.com', 3444455556, 1, 1, 1, 5),
    ('Mariana', 'Rodr�guez', 1234, 29684212, 'marianarodriguez@gmail.com', 3222233334, 1, 1, 1, 6),
    ('Javier', 'Hern�ndez', 1234, 40699925, 'javierhernandez@gmail.com', 3111122223, 1, 1, 1, 7),
    ('Valentina', 'Garc�a', 1234, 18008722, 'valentinagarcia@gmail.com', 3777788899, 1, 1, 1, 8),
    ('Camilo', 'Mart�nez', 1234, 29557139, 'camilomartinez@gmail.com', 3666677778, 1, 1, 1, 9),
    ('Daniela', 'Torres', 1234, 45020321, 'danielatorres@gmail.com', 3888888999, 1, 1, 1, 10);

--Crear Usuario ADMIN
insert into Users(Name,LastName,Password,DocumentNumber,Mail,Telephone,UserRoleId,UserStateId)
values('Admin','Admin',1234,'30236541','admin@admin.com','4795263',1,1),
    ('Dario', 'Martin', 1234, 47768238, 'dariomartin@gmail.com', '3998877665', 2, 1),
    ('Melissa', 'Fulgenzi', 1234, 22349641, 'melissafulgenzi@gmail.com', '3889998877', 2, 1),
    ('German', 'D�Gaudio', 1234, 44000670, 'germandgaudio@gmail.com', '3776665544', 2, 1);

INSERT INTO Projects(Name, ClientId,ServiceTypeId,UserId, ProjectTypeId, ProjectStateId)
VALUES   ('Casa en desnivel', 4,2, 4, 3, 2),
    ('Remodelaci�n de oficina', 7,2, 3, 1, 5),
    ('Construcci�n de edificio residencial', 2,1, 2, 2, 4),
    ('Renovaci�n de cocina', 5,3, 4, 1, 1),
    ('Ampliaci�n de casa', 3,2, 3, 3, 3),
    ('Dise�o de jard�n', 9,2, 2, 1, 2),
    ('Proyecto de infraestructura vial', 1,3, 4, 2, 5),
    ('Construcci�n de centro comercial', 6,1, 2, 3, 4),
    ('Remodelaci�n de ba�o', 8,1, 3, 1, 3),
    ('Casa en la playa', 10,1, 4, 2, 1),
    ('Proyecto de desarrollo de software', 2,1, 2, 3, 2),
    ('Construcci�n de hotel', 3,2, 3, 2, 4),
    ('Renovaci�n de fachada', 5,2, 4, 1, 5),
    ('Construcci�n de parque tem�tico', 9,1, 3, 3, 3),
    ('Remodelaci�n de local comercial', 1,2, 2, 1, 1);


	INSERT INTO BudgetStates
VALUES 
   ('Revisi�n'),
   ('Finalizado'),
   ('Aprobado'),
   ( 'Pagado');
END