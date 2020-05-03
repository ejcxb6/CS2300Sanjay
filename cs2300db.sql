use cs2300;
CREATE TABLE `student` (
  `idstudent` int NOT NULL,
  `Major` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idstudent`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
CREATE TABLE `teacher` (
  `idTeacher` int NOT NULL,
  `Department` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idTeacher`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
CREATE TABLE `user` (
  `nameUser` varchar(45) DEFAULT NULL,
  `idUser` int NOT NULL,
  PRIMARY KEY (`idUser`),
  CONSTRAINT `ID Student` FOREIGN KEY (`idUser`) REFERENCES `student` (`idstudent`),
  CONSTRAINT `ID Teacher` FOREIGN KEY (`idUser`) REFERENCES `teacher` (`idTeacher`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
CREATE TABLE `course` (
  `courseID` int NOT NULL,
  `Department` varchar(45) DEFAULT NULL,
  `Credit _hours` int DEFAULT NULL,
  `Name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`courseID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
CREATE TABLE `section` (
  `Section_number` int NOT NULL,
  `Class_Size` int DEFAULT NULL,
  `Date_Time` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Section_number`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
CREATE TABLE `has` (
  `CourseID` int NOT NULL,
  `Section Number` int NOT NULL,
  PRIMARY KEY (`CourseID`,`Section Number`),
  CONSTRAINT `course id ` FOREIGN KEY (`CourseID`) REFERENCES `course` (`courseID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
CREATE TABLE `teaches` (
  `ID` int NOT NULL,
  `SectionNumber` int NOT NULL,
  PRIMARY KEY (`ID`,`SectionNumber`),
  KEY `section#_idx` (`SectionNumber`),
  CONSTRAINT `section#` FOREIGN KEY (`SectionNumber`) REFERENCES `section` (`Section_number`),
  CONSTRAINT `Student ID` FOREIGN KEY (`ID`) REFERENCES `student` (`idstudent`),
  CONSTRAINT `Teacher ID` FOREIGN KEY (`ID`) REFERENCES `teacher` (`idTeacher`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
CREATE TABLE `takes` (
  `section_number` int NOT NULL,
  `ID` int DEFAULT NULL,
  `Grade` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`section_number`),
  KEY `studentID_idx` (`ID`),
  CONSTRAINT `section number` FOREIGN KEY (`section_number`) REFERENCES `section` (`Section_number`),
  CONSTRAINT `studentID` FOREIGN KEY (`ID`) REFERENCES `student` (`idstudent`),
  CONSTRAINT `TeacherID` FOREIGN KEY (`ID`) REFERENCES `teacher` (`idTeacher`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
