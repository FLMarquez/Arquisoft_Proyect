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
    ('Córdoba'),
    ('Corrientes'),
    ('Entre Ríos'),
    ('Formosa'),
    ('Jujuy'),
    ('La Pampa'),
    ('La Rioja'),
    ('Mendoza'),
    ('Misiones'),
    ('Neuquén'),
    ('Río Negro'),
    ('Salta'),
    ('San Juan'),
    ('San Luis'),
    ('Santa Cruz'),
    ('Santa Fe'),
    ('Santiago del Estero'),
    ('Tierra del Fuego'),
    ('Tucumán');

	INSERT INTO [dbo].[UserRoles] ([Description])
VALUES
    ('Admin'),
    ('Usuario'),
    ('Soporte'),
	('Técnico'),
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
VALUES('Se trabajará en el completamiento del anteproyecto, desarrollando el material necesario para la ejecución en obra. En esta etapa deberá recurrirse al trabajo interdisciplinar, para el estudio de suelo y el cálculo estructural (cimientos, vigas, columnas, losas, etc).
Todo encuadrado en las normativas vigentes.
Tiempo de trabajo aproximado:
Entre 1 y 3 meses (dependiendo de la complejidad de proyecto, necesidad de investigación y búsqueda, definición de cliente)
Material a entregar:
Confección de plano municipal
Presentación de planos para la realización de trámites correspondientes
Diseño de mobiliario escala 1:20
Planilla de aberturas
Planos de estructuras
Detalles constructivos
Planos de instalaciones (sanitario-agua-gas-electricidad-pluvial)
Cómputo métrico (cálculo estimativo de materiales y artefactos a comprar, previo asesoramiento
y selección de los mismos)
Asesoramiento/análisis de costo/análisis de factibilidad','Proyecto con detalle')

INSERT ServiceTypes(ServiceTypeName,ServiceTypeDescription)
VALUES('Control de obra
Planificación de obra (secuencia lógica de ejecución de cada actividad o rubro)
Programación de obra (Estimación de tiempo para ejecutar cada actividad y rendimiento)
Tiempo de trabajo aproximado:
Duración de la obra, segun la planificación
Material a entregar:
Certificaciones de avance de obra cada 15 días','Conducción Técnica')

INSERT ServiceTypes(ServiceTypeName,ServiceTypeDescription)
VALUES('Se trabajará con la IDEA DE PROYECTO, atendiendo a la situación particular del cliente según la información brindada por el mismo (necesidades, deseos, recursos disponibles, lote, orientaciones, implantación, programa, usuario) Se escucha del cliente, se capta y procesa la información, estudian y analizan todas estas variables, brindando asesoramiento profesional y personalizado, determinando las mejores alernativas para llevar a cabo el encargo, según cada caso en particular..
Todo encuadrado en  el conocimiento y aplicación las normativas vigentes.
Tiempo de trabajo aproximado:
Entre 1 y 3 meses (dependiendo de la complejidad de proyecto, necesidad de investigación y búsqueda, definición de cliente)
Material a entregar:
-Memoria descriptiva del proyecto
-Plantas (Escala1:100)
-Cortes (Escala1:100)
-Vistas (Escala1:100)
-Esquema de planteo estructural
-Renders (cantidad a definir según necesidad)
-Esquemas explicativos, axonometricas, y otros recursos gráficos a convenir según cada caso, necesarios para TRANSMITIR Y PLASMAR las ideas de proyecto','Anteproyecto')



	-- Provincia de Buenos Aires
INSERT INTO Localities (ProvinceId, Description)
VALUES
    (1, 'Buenos Aires'),
    (1, 'La Plata'),
    (1, 'Mar del Plata'),
    (1, 'Bahía Blanca'),
    (1, 'San Isidro'),
    (1, 'Pilar'),
    (1, 'Quilmes'),
    (1, 'Morón'),
    (1, 'Tandil'),
    (1, 'Lomas de Zamora');

-- Provincia de Catamarca
INSERT INTO Localities(ProvinceId, Description)
VALUES
    (2, 'San Fernando del Valle de Catamarca'),
    (2, 'Andalgalá'),
    (2, 'Belén'),
    (2, 'Santa María'),
    (2, 'Recreo'),
    (2, 'Fiambalá'),
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
    (3, 'Presidencia Roque Sáenz Peña'),
    (3, 'Villa Ángela'),
    (3, 'Charata'),
    (3, 'General San Martín'),
    (3, 'Juan José Castelli'),
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

-- Provincia de Córdoba
INSERT INTO Localities (ProvinceId, Description)
VALUES
    (5, 'Córdoba'),
    (5, 'Villa Carlos Paz'),
    (5, 'Río Cuarto'),
    (5, 'Alta Gracia'),
    (5, 'San Francisco'),
    (5, 'Villa María'),
    (5, 'Jesús María'),
    (5, 'Bell Ville'),
    (5, 'Cosquín'),
    (5, 'La Falda');

-- Provincia de Corrientes
INSERT INTO Localities (ProvinceId, Description)
VALUES
    (6, 'Corrientes'),
    (6, 'Goya'),
    (6, 'Mercedes'),
    (6, 'Curuzú Cuatiá'),
    (6, 'Bella Vista'),
    (6, 'Esquina'),
    (6, 'Ituzaingó'),
    (6, 'Santo Tomé'),
    (6, 'Monte Caseros'),
    (6, 'Paso de los Libres');

-- Provincia de Entre Ríos
INSERT INTO Localities (ProvinceId, Description)
VALUES
    (7, 'Paraná'),
    (7, 'Concordia'),
    (7, 'Gualeguaychú'),
    (7, 'Gualeguay'),
    (7, 'Chajarí'),
    (7, 'Villaguay'),
    (7, 'Colón'),
    (7, 'Victoria'),
    (7, 'Diamante'),
    (7, 'La Paz');

-- Provincia de Formosa
INSERT INTO Localities (ProvinceId, Description)
VALUES
    (8, 'Formosa'),
    (8, 'Clorinda'),
    (8, 'Pirané'),
    (8, 'El Colorado'),
    (8, 'Las Lomitas'),
    (8, 'Riacho He Hé'),
    (8, 'Laguna Yema'),
    (8, 'Ibarreta'),
    (8, 'General Güemes'),
    (8, 'San Martín 2');

-- Provincia de Jujuy
INSERT INTO Localities (ProvinceId, Description)
VALUES
    (9, 'San Salvador de Jujuy'),
    (9, 'Palpalá'),
    (9, 'San Pedro'),
    (9, 'Libertador General San Martín'),
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
    (10, 'Realicó'),
    (10, 'Eduardo Castex'),
    (10, 'General Acha'),
    (10, '25 de Mayo'),
    (10, 'General Manuel J. Campos'),
    (10, 'Catriló'),
    (10, 'Macachín');

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
    (11, 'Villa Unión'),
    (11, 'Villa Castelli'),
    (11, 'Sanagasta');

-- Provincia de Mendoza
INSERT INTO Localities (ProvinceId, Description)
VALUES
    (12, 'Mendoza'),
    (12, 'San Rafael'),
    (12, 'Godoy Cruz'),
    (12, 'Luján de Cuyo'),
    (12, 'Las Heras'),
    (12, 'Maipú'),
    (12, 'San Martín'),
    (12, 'Malargüe'),
    (12, 'Tunuyán'),
    (12, 'General Alvear');

-- Provincia de Misiones
INSERT INTO Localities (ProvinceId, Description)
VALUES
    (13, 'Posadas'),
    (13, 'Eldorado'),
    (13, 'Puerto Iguazú'),
    (13, 'Oberá'),
    (13, 'Apostoles'),
    (13, 'San Vicente'),
    (13, 'Alem'),
    (13, 'Jardín América'),
    (13, 'Montecarlo'),
    (13, 'Puerto Rico');

-- Provincia de Neuquén
INSERT INTO Localities (ProvinceId, Description)
VALUES
    (14, 'Neuquén'),
    (14, 'San Martín de los Andes'),
    (14, 'Cutral Có'),
    (14, 'Plottier'),
    (14, 'Zapala'),
    (14, 'Centenario'),
    (14, 'Villa La Angostura'),
    (14, 'Chos Malal'),
    (14, 'Senillosa'),
    (14, 'Rincón de los Sauces');

-- Provincia de Río Negro
INSERT INTO Localities (ProvinceId, Description)
VALUES
    (15, 'Viedma'),
    (15, 'San Carlos de Bariloche'),
    (15, 'General Roca'),
    (15, 'Cipolletti'),
    (15, 'Allen'),
    (15, 'El Bolsón'),
    (15, 'Ingeniero Jacobacci'),
    (15, 'Villa Regina'),
    (15, 'Choele Choel'),
    (15, 'Cinco Saltos');

-- Provincia de Salta
INSERT INTO Localities (ProvinceId, Description)
VALUES
    (16, 'Salta'),
    (16, 'San Ramón de la Nueva Orán'),
    (16, 'General Güemes'),
    (16, 'Tartagal'),
    (16, 'Cafayate'),
    (16, 'San Pedro de Jujuy'),
    (16, 'Metán'),
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
    (17, 'Santa Lucía'),
    (17, 'Caucete'),
    (17, 'Albardón'),
    (17, 'Jáchal'),
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
    (18, 'Concarán');

-- Provincia de Santa Cruz
INSERT INTO Localities (ProvinceId, Description)
VALUES
    (19, 'Río Gallegos'),
    (19, 'Caleta Olivia'),
    (19, 'El Calafate'),
    (19, 'Puerto Deseado'),
    (19, 'Río Turbio'),
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
    (20, 'Santo Tomé'),
    (20, 'Constitución'),
    (20, 'San Lorenzo'),
    (20, 'Granadero Baigorria'),
    (20, 'Firmat');

-- Provincia de Santiago del Estero
INSERT INTO Localities (ProvinceId, Description)
VALUES
    (21, 'Santiago del Estero'),
    (21, 'La Banda'),
    (21, 'Termas de Río Hondo'),
    (21, 'Añatuya'),
    (21, 'Fernández'),
    (21, 'Clodomira'),
    (21, 'Frías'),
    (21, 'Loreto'),
    (21, 'Suncho Corral'),
    (21, 'Beltrán');

-- Provincia de Tierra del Fuego, Antártida e Islas del Atlántico Sur
INSERT INTO Localities (ProvinceId, Description)
VALUES
    (22, 'Ushuaia'),
    (22, 'Río Grande'),
    (22, 'Tolhuin'),
    (22, 'Puerto Almanza'),
    (22, 'San Julián'),
    (22, 'Puerto Williams'),
    (22, 'Puerto Toro'),
    (22, 'Puerto Yartou'),
    (22, 'Caleta María'),
    (22, 'Puerto Roballo');

-- Provincia de Tucumán
INSERT INTO Localities (ProvinceId, Description)
VALUES
    (23, 'San Miguel de Tucumán'),
    (23, 'Yerba Buena'),
    (23, 'Banda del Río Salí'),
    (23, 'Concepción'),
    (23, 'Aguilares'),
    (23, 'Tafí Viejo'),
    (23, 'Famaillá'),
    (23, 'Tafí del Valle'),
    (23, 'Monteros'),
    (23, 'Lules');

--Crear Cliente TEST
INSERT INTO Addresses (AddressLine, PostalCode, Numbering, Department, Floor, Neighborhood, ProvinceId, LocalityId, AdditionalInstructions)
            VALUES ('Boyero', 5000, 528, 1, 1, 'Chateau Carreras', 5, 3, NULL),
			('Cerrito', 5000, 173, 1, 1, 'Arguello', 5, 3, NULL),
			('Chancay', 5003, 1401, 1, 1, 'Observatorio', 5, 2, NULL),
			('San Martín', 5000, 867, 1, 1, 'San Vicente', 7, 5, NULL),
			('9 de Julio', 5010, 422, 1, 1, 'San Martín', 8, 4, NULL),
			('25 de Mayo', 5800, 8, 1, 1, '9 de Julio', 3, 3, NULL),
			('Rosario', 5125, 914, 1, 1, 'Bella Vista', 2, 4, NULL),
			('Colon', 4052, 777, 1, 1, 'Quintana', 1, 3, NULL),
			('Salta', 3582, 1522, 1, 1, 'Belgrano', 1, 2, NULL),
			('Jujuy', 5008, 4006, 1, 1, 'Palermo', 9, 1, NULL);

		
			
INSERT INTO Clients (Name, LastName, Password, DocumentNumber, Mail, Telephone, ClientStateId, ClientRoleId, PreferencesId, AddressId)
            VALUES ('Marcos', 'Mateos', 1234, 38474256, 'marcosmateos@gmail.com', 3551122334, 1, 1, 1, 1),
    ('Juan', 'Gómez', 1234, 47768238, 'juangomez@gmail.com', 3998877665, 1, 1, 1, 2),
    ('Luisa', 'Sánchez', 1234, 22349641, 'luisasanchez@gmail.com', 3889998877, 1, 1, 1, 3),
    ('Andrés', 'Pérez', 1234, 44000670, 'andresperez@gmail.com', 3776665544, 1, 1, 1, 4),
    ('Carolina', 'López', 1234, 15487263, 'carolinalopez@gmail.com', 3444455556, 1, 1, 1, 5),
    ('Mariana', 'Rodríguez', 1234, 29684212, 'marianarodriguez@gmail.com', 3222233334, 1, 1, 1, 6),
    ('Javier', 'Hernández', 1234, 40699925, 'javierhernandez@gmail.com', 3111122223, 1, 1, 1, 7),
    ('Valentina', 'García', 1234, 18008722, 'valentinagarcia@gmail.com', 3777788899, 1, 1, 1, 8),
    ('Camilo', 'Martínez', 1234, 29557139, 'camilomartinez@gmail.com', 3666677778, 1, 1, 1, 9),
    ('Daniela', 'Torres', 1234, 45020321, 'danielatorres@gmail.com', 3888888999, 1, 1, 1, 10);

--Crear Usuario ADMIN
insert into Users(Name,LastName,Password,DocumentNumber,Mail,Telephone,UserRoleId,UserStateId)
values('Admin','Admin',1234,'30236541','admin@admin.com','4795263',1,1),
    ('Dario', 'Martin', 1234, 47768238, 'dariomartin@gmail.com', '3998877665', 2, 1),
    ('Melissa', 'Fulgenzi', 1234, 22349641, 'melissafulgenzi@gmail.com', '3889998877', 2, 1),
    ('German', 'D´Gaudio', 1234, 44000670, 'germandgaudio@gmail.com', '3776665544', 2, 1);

INSERT INTO Projects(Name, ClientId,ServiceTypeId,UserId, ProjectTypeId, ProjectStateId)
VALUES   ('Casa en desnivel', 4,2, 4, 3, 2),
    ('Remodelación de oficina', 7,2, 3, 1, 5),
    ('Construcción de edificio residencial', 2,1, 2, 2, 4),
    ('Renovación de cocina', 5,3, 4, 1, 1),
    ('Ampliación de casa', 3,2, 3, 3, 3),
    ('Diseño de jardín', 9,2, 2, 1, 2),
    ('Proyecto de infraestructura vial', 1,3, 4, 2, 5),
    ('Construcción de centro comercial', 6,1, 2, 3, 4),
    ('Remodelación de baño', 8,1, 3, 1, 3),
    ('Casa en la playa', 10,1, 4, 2, 1),
    ('Proyecto de desarrollo de software', 2,1, 2, 3, 2),
    ('Construcción de hotel', 3,2, 3, 2, 4),
    ('Renovación de fachada', 5,2, 4, 1, 5),
    ('Construcción de parque temático', 9,1, 3, 3, 3),
    ('Remodelación de local comercial', 1,2, 2, 1, 1);


	INSERT INTO BudgetStates
VALUES 
   ('Revisión'),
   ('Finalizado'),
   ('Aprobado'),
   ( 'Pagado');
END