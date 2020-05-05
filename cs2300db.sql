use cs2300;

CREATE TABLE `users` (
  `nameUser` varchar(45) DEFAULT NULL,
  `ID` int NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `student` (
  `ID` int NOT NULL,
  `Major` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  CONSTRAINT `IDstudent` FOREIGN KEY (`ID`) REFERENCES `users` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `teacher` (
  `ID` int NOT NULL,
  `Department` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  CONSTRAINT `IDteacher` FOREIGN KEY (`ID`) REFERENCES `users` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `course` (
  `courseID` int NOT NULL,
  `Department` varchar(45) DEFAULT NULL,
  `Credit_hours` int DEFAULT NULL,
  `Name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`courseID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `section` (
  `section_Number` int NOT NULL,
  `Class_Size` int DEFAULT NULL,
  `Date_Time` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`section_Number`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `has` (
  `CourseID` int NOT NULL,
  `section_Number` int NOT NULL,
  PRIMARY KEY (`CourseID`,`section_Number`),
  CONSTRAINT `course id ` FOREIGN KEY (`CourseID`) REFERENCES `course` (`courseID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `takes` (
  `section_Number` int NOT NULL,
  `ID` int DEFAULT NULL,
  `Grade` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`section_Number`),
  KEY `studentID_idx` (`ID`),
  CONSTRAINT `section number` FOREIGN KEY (`section_Number`) REFERENCES `section` (`section_Number`),
  CONSTRAINT `studentID` FOREIGN KEY (`ID`) REFERENCES `student` (`ID`),
  CONSTRAINT `TeacherID` FOREIGN KEY (`ID`) REFERENCES `teacher` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `teaches` (
  `ID` int NOT NULL,
  `section_Number` int NOT NULL,
  PRIMARY KEY (`ID`,`section_Number`),
  KEY `sectionNumber_idx` (`section_Number`),
  CONSTRAINT `sectionNumber` FOREIGN KEY (`section_Number`) REFERENCES `section` (`section_Number`),
  CONSTRAINT `teacher` FOREIGN KEY (`ID`) REFERENCES `teacher` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


#Q1
SELECT * FROM CS2300.student, cs2300.user where user.ID = student.ID;
#Q2
SELECT * FROM CS2300.teacher, cs2300.user where user.ID = teacher.ID;

#Q4
UPDATE section
SET section.Class_Size = section.Class_Size + 1 
WHERE section.section_Number IN (SELECT section.section_Number FROM student, takes, course, has, section WHERE user.ID = student.ID AND 
									student.ID = takes.ID AND takes.courseID = courseID);

#Q5
SELECT course.name, course.courseID, section.section_Number, section.Date_Time, course.Credit_hours
FROM student, takes, course, has, section, users
WHERE users.ID = student.ID AND student.ID = takes.ID AND takes.section_Number = section.section_Number AND course.courseID = has.courseID AND has.section_Number = section.section_Number;

#Q6
SELECT course.name, course.courseID, section.section_Number, section.Date_Time, course.Credit_hours
FROM teacher, teaches, course, has, section, users
WHERE teacher.ID = users.ID AND teacher.ID = teaches.ID AND teaches.section_Number = section.section_Number AND course.courseID = has.courseID AND has.section_Number = section.section_Number;

#Q9
SELECT course.name, course.courseID, section.section_Number, section.Date_Time, course.Credit_hours, takes.grade
FROM student, takes, course, has, section, users
WHERE users.ID = student.ID AND student.ID = takes.ID AND takes.section_Number = section.section_Number AND course.courseID = has.courseID AND has.section_Number = section.section_Number;

#Q10
SELECT student.ID, takes.grade
FROM student, takes, Teaches 
WHERE student.ID = takes.ID AND teaches.section_Number = takes.section_Number 

#Q
