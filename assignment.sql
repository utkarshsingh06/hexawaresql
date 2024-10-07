use SISDB

--TASK1 Database Design:


-- 1. Create the database named "SISDB"
create database SISDB

/*2. Define the schema for the Students, Courses, Enrollments, Teacher, and Payments tables based
on the provided schema. Write SQL scripts to create the mentioned tables with appropriate data
types, constraints, and relationships. */

--create Students table
create table Students(
student_id int identity primary key,
first_name varchar(30) not null,
last_name varchar(30) not null,
date_of_birth date not null,
email varchar(35) unique not null,
phone varchar(15)
)

-- create Teacher table
create table Teacher(
teacher_id int identity primary key,
first_name varchar(25) null,  
last_name varchar(25) not null,
email varchar(35) unique not null
)

--create Courses table
create table Courses(
course_id int identity primary key,
course_name varchar(50),
credits int check(credits>0),
teacher_id int, foreign key(teacher_id)references Teacher(teacher_id)
)
--create Enrollments table
create table Enrollments(
enrollment_id int identity primary key,
student_id int, foreign key(student_id)references Students(student_id),
course_id int, foreign key(course_id)references Courses(course_id),
enrollment_date date not null
)
--create Payments table
create table Payments(
payment_id int identity primary key,
student_id int, foreign key(student_id)references Students(student_id),
amount decimal(10,2) not null,
payment_date date not null
)

-- 3. Create an ERD (Entity Relationship Diagram) for the database.
-- it is saved under database diagrams in the SISDB database

/*4. Insert at least 10 sample records into each of the following tables.
i. Students
ii. Courses
iii. Enrollments
iv. Teacher
v. Payments*/

--insert  10 values into student tables
insert into Students (first_name, last_name, date_of_birth, email, phone)
values('Utkarsh', 'Singh', '2000-07-16', 'john.doe@example.com', '9696116536'),
('Dave', 'Smith', '1999-08-22', 'jane.smith@example.com', '9987654321'),
('Michael', 'Pheleps', '2001-11-30', 'michael.johnson@example.com', '9989334455'),
('Esha', 'Sinha', '2002-01-10', 'emily.davis@example.com', '8777889900'),
('David', 'Becham', '2000-03-18', 'david.brown@example.com', '7933445566'),
('Sarah', 'Jones', '1998-07-09', 'sarah.wilson@example.com', '7044556677'),
('Chris', 'Smith', '2001-02-25', 'chris.taylor@example.com', '9088990011'),
('Jessica', 'Miller', '1999-09-12', 'jessica.miller@example.com', '9266778899'),
('Vinod', 'Sharma', '2003-04-17', 'daniel.martinez@example.com', '9955667788'),
('Sophia', 'Dsouza', '2002-06-05', 'sophia.anderson@example.com', '8888776655')

--insert 10 values into Teacher table
insert into Teacher (first_name,last_name,email)
values
('Mukund', 'Sinha', 'mukund.sinha@school.edu'),
('Akash', 'Jain', 'akash.jain@school.edu'),
('Mayank', 'Barota', 'mayankb@school.edu'),
('Sanjay', 'Dubey', 'sanjaydub@school.edu'),
('David', 'Wilson', 'david.wilson@school.edu'),
('Sheetal', 'Pandey', 'sheetal.pandey@school.edu'),
('Chris', 'Taylor', 'chris.taylor@school.edu'),
('Jessica', 'Martinez', 'jessica.martinez@school.edu'),
('Daniayal', 'Sheikh', 'daniyal.sheikh@school.edu'),
('Rishi', 'Dhawan', 'rishi.dhawan@school.edu')

insert into Teacher (first_name,last_name,email)
values
('Abhilash', 'Sharma', 'abhilask.sinha@school.edu'),
('Akash', 'Panda', 'akashpan.jain@school.edu'),
('Mayanti', 'Bakshi', 'mayanti@school.edu')

--insert into Courses table
insert into  Courses (course_name, credits, teacher_id)
values
('Mathematics 101', 3, 1),
('Physics 101', 4, 2),
('Chemistry 101', 3, 3),
('Biology 101', 4, 4),
('English Literature 101', 3, 5),
('History 101', 3, 6),
('Computer Science 101', 4, 7),
('Psychology 101', 3, 8),
('Sociology 101', 3, 9),
('Philosophy 101', 3, 10)

insert into  Courses (course_name, credits, teacher_id)
values
('Enviromental 101', 4, 5),
('Value 101', 4, 2),
('Hindi 101', 3, 3)

--insert into enrollments
insert into Enrollments (student_id, course_id, enrollment_date)
values
    (1, 3, '2024-01-15'),  
    (2, 5, '2024-02-20'),  
    (3, 7, '2024-03-25'),  
    (4, 8, '2024-04-30'), 
    (5, 2, '2024-05-05'),  
    (6, 4, '2024-06-10'),  
    (7, 9, '2024-07-15'),  
    (8, 1, '2024-08-20'),  
    (9, 6, '2024-09-25'),  
    (10, 10, '2024-10-30')

--insert into Payments table
insert into Payments (student_id, amount, payment_date)
values
    (1, 100.00, '2024-01-15'),
    (2, 150.00, '2024-02-20'),
    (3, 200.00, '2024-03-25'),
    (4, 120.00, '2024-04-30'),
    (5, 180.00, '2024-05-05'),
    (6, 250.00, '2024-06-10'),
    (7, 130.00, '2024-07-15'),
    (8, 160.00, '2024-08-20'),
    (9, 140.00, '2024-09-25'),
    (10, 220.00, '2024-10-30')

--5. Create appropriate Primary Key and Foreign Key constraints for referential integrity.
--Adding foreign key and referntial integrity constraints

ALTER TABLE Courses
ADD CONSTRAINT FK_Courses_Teacher
FOREIGN KEY (teacher_id) REFERENCES Teacher(teacher_id) ON DELETE SET NULL;

ALTER TABLE Enrollments
ADD CONSTRAINT FK_Enrollments_Students
FOREIGN KEY (student_id) REFERENCES Students(student_id) ON DELETE CASCADE;

ALTER TABLE Enrollments
ADD CONSTRAINT FK_Enrollments_Courses
FOREIGN KEY (course_id) REFERENCES Courses(course_id) ON DELETE CASCADE;

ALTER TABLE Payments
ADD CONSTRAINT FK_Payments_Students
FOREIGN KEY (student_id) REFERENCES Students(student_id) ON DELETE CASCADE;

--END OF TASK 1----------------------------------------------------------------------------------



--TASK 2  Select, Where, Between, AND, LIKE: 

/* 1. Write an SQL query to insert a new student into the "Students" table with the following details:
a. First Name: John
� Hexaware Technologies Limited. All rights www.hexaware.com
b. Last Name: Doe
c. Date of Birth: 1995-08-15
d. Email: john.doe@example.com
e. Phone Number: 12345678908 */

insert into Students(first_name, last_name,date_of_birth,email,phone)
values
('John','Doe','1995-08-15','john.does@example.com','1234567890')
select * from Enrollments
select * from Students
select * from Courses
select * from Teacher
select * from Payments
/* 2. Write an SQL query to enroll a student in a course. Choose an existing student and course and
insert a record into the "Enrollments" table with the enrollment date.*/

insert into Enrollments(student_id,course_id,enrollment_date)
values
(3,4,'2024-09-19')

/*3. Update the email address of a specific teacher in the "Teacher" table. Choose any teacher and
modify their email address.*/

update Teacher
set email='taylor.chris@school.edu'
where teacher_id=7

/*4. Write an SQL query to delete a specific enrollment record from the "Enrollments" table. Select
an enrollment record based on the student and course.*/

delete from Enrollments
where student_id=8 and course_id=1

/*5. Update the "Courses" table to assign a specific teacher to a course. Choose any course and
teacher from the respective tables.*/

update Courses
set teacher_id=3
where course_id=2

/*6. Delete a specific student from the "Students" table and remove all their enrollment records
from the "Enrollments" table. Be sure to maintain referential integrity.*/

delete from Students
where student_id=6  
--since referential integrity is maintained the specific students enrollments from enrollment
--table will be removed automatically

/*7. Update the payment amount for a specific payment record in the "Payments" table. Choose any
payment record and modify the payment amount.*/

update Payments
set amount=280.45
where payment_id=5

--END OF TASK 2 ----------------------------------------------------------------------------------------------------

--TASK 3  Aggregate functions, Having, Order By, GroupBy and Joins:

/*1. Write an SQL query to calculate the total payments made by a specific student. You will need to
join the "Payments" table with the "Students" table based on the student's ID*/

select * from Students
select * from Payments
select * from Courses
select * from Enrollments
select * from Payments

select CONCAT_WS(' ',first_name,last_name) as [Name] from Students

select s.student_id, CONCAT_WS(' ',s.first_name,s.last_name) as [Name], COUNT(p.payment_date) as payment_cnt
from Students as s JOIN Payments as p
on s.student_id=p.student_id
group by s.student_id,s.first_name,s.last_name

/*2. Write an SQL query to retrieve a list of courses along with the count of students enrolled in each
course. Use a JOIN operation between the "Courses" table and the "Enrollments" table*/

select c.course_id,c.course_name, c.credits,c.teacher_id, count(e.student_id) as [student_cnt]
from Courses as c left join Enrollments as e on c.course_id=e.course_id
group by c.course_id,c.course_name,c.credits,c.teacher_id

/* 3. Write an SQL query to find the names of students who have not enrolled in any course. Use a
LEFT JOIN between the "Students" table and the "Enrollments" table to identify students
without enrollments.*/

select CONCAT_WS(' ',s.first_name,s.last_name) as [Name], count(s.student_id) as course_cnt from Students as s
left join Enrollments as e on s.student_id=e.student_id where e.student_id is null
group by s.student_id,s.first_name,s.last_name

/* 4. Write an SQL query to retrieve the first name, last name of students, and the names of the
courses they are enrolled in. Use JOIN operations between the "Students" table and the
"Enrollments" and "Courses" tables.*/

SELECT s.first_name,s.last_name,c.course_name AS course_enrolled
FROM Students AS s JOIN Enrollments AS e ON s.student_id = e.student_id
JOIN Courses AS c ON e.course_id = c.course_id

/* 5. Create a query to list the names of teachers and the courses they are assigned to. Join the
"Teacher" table with the "Courses" table.*/

select t.first_name,t.last_name,c.course_name from Teacher as t
left join Courses as c on t.teacher_id=c.teacher_id
order by t.first_name

/* 6. Retrieve a list of students and their enrollment dates for a specific course. You'll need to join the
"Students" table with the "Enrollments" and "Courses" tables.*/

select s.first_name, s.last_name ,c.course_name, e.enrollment_date from Students as s
join Enrollments as e on s.student_id=e.student_id
join Courses as c on e.course_id=c.course_id
where c.course_name in ('Physics 101')
order by s.first_name

/* 7. Find the names of students who have not made any payments. Use a LEFT JOIN between the
"Students" table and the "Payments" table and filter for students with NULL payment records.*/

select concat_ws(' ',s.first_name,s.last_name) as[Students with no payments]
from Students as s left join Payments as p 
on s.student_id=p.student_id
where p.payment_id is null

/* 8. Write a query to identify courses that have no enrollments. You'll need to use a LEFT JOIN
between the "Courses" table and the "Enrollments" table and filter for courses with NULL
enrollment records.*/

select c.course_id,c.course_name,c.credits from Courses as c left join Enrollments as e
on c.course_id=e.course_id
where e.course_id is null
order by c.course_id

/* 9. Identify students who are enrolled in more than one course. Use a self-join on the "Enrollments"
table to find students with multiple enrollment records.*/

select e1.student_id,s.first_name,s.last_name, count(e1.course_id)as [no. of courses]
from Enrollments as e1
join Enrollments as e2 on e1.student_id=e2.student_id and e1.course_id=e2.course_id
join Students as s on e1.student_id=s.student_id
group by e1.student_id,s.first_name,s.last_name
having count(e1.course_id) >1 --having is used in case of group by , where is not used

/* 10. Find teachers who are not assigned to any courses. Use a LEFT JOIN between the "Teacher"
table and the "Courses" table and filter for teachers with NULL course assignments.*/


select t.teacher_id,t.first_name,t.last_name, t.email from Teacher as t
left join Courses as c on t.teacher_id=c.teacher_id
where c.teacher_id is null

--END OF TASK 3 -----------------------------------------------------------------------

--TASK 4 Subquery and its type

/* 1. Write an SQL query to calculate the average number of students enrolled in each course. Use
aggregate functions and subqueries to achieve this.*/


select avg(numb_of_stud) as avg_of_stud from
(
select e.course_id,count(e.student_id)as [numb_of_stud] from Enrollments as e
group by e.course_id
) as a1

/* 2. Identify the student(s) who made the highest payment. Use a subquery to find the maximum
payment amount and then retrieve the student(s) associated with that amount.*/

select concat_ws(' ',first_name,last_name)as [name],q2.Total_Sum  as [Max Sum]from Students as s
left join (
select p.student_id,sum(p.amount) as [Total_Sum] from Payments as p
group by p.student_id
) as q2 on s.student_id=q2.student_id
where q2.Total_Sum=(
select max(Total_Sum) as [maximum_payment] 
from(
select sum(p.amount) as [Total_Sum] from Payments as p
group by p.student_id
) as q1
)


/*3. Retrieve a list of courses with the highest number of enrollments. Use subqueries to find the
course(s) with the maximum enrollment count.*/

select c.course_name, c.course_id from Courses as c
join (
select course_id,count(course_id) as[no_of_courses] from Enrollments
group by course_id
) as q2 on c.course_id=q2.course_id
where q2.no_of_courses=(
select max(no_of_courses) [max_no_course] from
(
select count(course_id)  [no_of_courses] from Enrollments
group by course_id
) as q1
)

/* 4. Calculate the total payments made to courses taught by each teacher. Use subqueries to sum
payments for each teacher's courses.
*/
select * from Payments
select * from Courses
select * from Enrollments
SELECT t.teacher_id, t.first_name, t.last_name, 
       SUM(p.amount) AS total_payments
FROM Teacher t
JOIN Courses c ON t.teacher_id = c.teacher_id
JOIN Enrollments e ON c.course_id = e.course_id
JOIN Payments p ON e.student_id = p.student_id
GROUP BY t.teacher_id, t.first_name, t.last_name;

/*5. Identify students who are enrolled in all available courses. Use subqueries to compare a
student's enrollments with the total number of courses.

*/
select s.first_name,s.last_name from Students as s
join (
select e1.student_id,count(e1.student_id) as [Student_cnt] from Enrollments as e1
group by e1.student_id) as q2 on s.student_id=q2.student_id
where q2.Student_cnt=(
select count(course_id) from Courses [number_ course]
)
/* 6. Retrieve the names of teachers who have not been assigned to any courses. Use subqueries to
find teachers with no course assignments.
*/

select t.first_name, t.last_name from Teacher as t
where t.teacher_id not in (
select c.teacher_id from Courses as c
join Teacher as t1 on c.teacher_id=t1.teacher_id
)
/* 7. Calculate the average age of all students. Use subqueries to calculate the age of each student
based on their date of birth. */


select avg(age_stud) as [avg_age_students] from(

select datediff(year,date_of_birth,getdate()) as [age_stud] from Students
) as s1

/* 8. Identify courses with no enrollments. Use subqueries to find courses without enrollment
records.
*/

select course_name [Course_name] from Courses where
course_id not in
(select e.course_id from Enrollments as e
join Courses as c on e.course_id=c.course_id)

/* 9. Calculate the total payments made by each student for each course they are enrolled in. Use
subqueries and aggregate functions to sum payments.*/

--do again


SELECT s.student_id, s.first_name, s.last_name, c.course_id, c.course_name,
       (SELECT SUM(p.amount)
        FROM Payments p
        JOIN Enrollments e ON p.student_id = e.student_id
        WHERE e.course_id = c.course_id AND e.student_id = s.student_id) AS total_payments
FROM Students s
JOIN Enrollments e ON s.student_id = e.student_id
JOIN Courses c ON e.course_id = c.course_id
GROUP BY s.student_id, s.first_name, s.last_name, c.course_id, c.course_name;

select * from Payments

/* 10. Identify students who have made more than one payment. Use subqueries and aggregate
functions to count payments per student and filter for those with counts greater than one.*/

select first_name, last_name from Students
where student_id in
(
select p.student_id from Payments as p 
group by p.student_id
having count(p.student_id)>1
)


/* 11. Write an SQL query to calculate the total payments made by each student. Join the "Students"
table with the "Payments" table and use GROUP BY to calculate the sum of payments for each
student.*/


SELECT s.student_id, s.first_name, s.last_name, 
       (SELECT SUM(p.amount) 
        FROM Payments p 
        WHERE p.student_id = s.student_id) AS total_payments
FROM Students s;

/* 12. Retrieve a list of course names along with the count of students enrolled in each course. Use
JOIN operations between the "Courses" table and the "Enrollments" table and GROUP BY to
count enrollments.*/

/*select c.course_name, count(e.student_id) from Courses as c
left join Enrollments as e on c.course_id=e.course_id
group by c.course_id,c.course_name*/
select course_name ,
(
select count(student_id) from Enrollments as e 
where e.course_id=c.course_id) as [no_of_students]
from Courses as c



/* 13. Calculate the average payment amount made by students. Use JOIN operations between the
"Students" table and the "Payments" table and GROUP BY to calculate the average.*/

SELECT s.student_id, s.first_name, s.last_name, 
       (SELECT avg(p.amount) 
        FROM Payments p 
        WHERE p.student_id = s.student_id) AS total_payments
FROM Students s;

