USE StudentInfoDatabase;

CREATE TABLE StudStatus
(
	Id INT PRIMARY KEY,
	StatusDescr VARCHAR(100)
);DELETE FROM StudStatus;INSERT INTO StudStatus
	(Id, StatusDescr)
VALUES
	(1, 'Studying'),
	(2, 'SoloPrep'),
	(3, 'Remote'),
	(4, 'OhHoldGrade'),
	(5, 'OhHoldSickness'),
	(6, 'OhHoldMaternity') 


INSERT INTO StudStatus
	(Id, StatusDescr)
VALUES
	(7, 'Graduated'),
	(8, 'SemiGraduated')

SELECT * FROM StudStatus;

-----------
USE StudentInfoDatabase;

SELECT * FROM Students;

SELECT * FROM Users;
