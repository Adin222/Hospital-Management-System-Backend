# Hospital Managment System

Welcome to my repository! This is my Hospital Management System project, where I have developed an API that manages patients, staff, and appointments. The database used here is PostgreSQL, and to make testing the routes easier, I have also included Swagger API documentation.

Here is the description of my system:

My server follows a structured architecture where repositories handle direct communication with the database. These repositories are then injected into services, which manage data processing and business logic. I use DTOs (Data Transfer Objects) to return only the necessary attributes of an object.

In this system, only employees have access to log in. There are three types of employees: Receptionists, Doctors, and Admins, each with their own roles and responsibilities. When an employee logs in his JWT gets generated, then he can only make requests based on his authorization. My log in is simple, server generates JWT and it is given in response, then I save it into the localstorage and that's how i maintain logged user state. 

## Admin employee

Admin in this system is a user that can manage empoyees and do what every other employee can do but not vice versa. When a doctor or a receptionist gets a job, he goes to create employees section and creates an employee acording to his personal data, then an employee is saved into the database and his role is assigend. Admin can read, write, update and delete every user and patient in the system. This way Admin can change password if user forgets it. 

## Receptionist employee

A receptionist can create, view, edit, and delete both patients and appointments. Whenever a new appointment is created, the system also records who created it. Receptionists can access all recorded patient profiles and view their medical records. When a patient cancels an appointment, the receptionist must manually update its status. After a certain period, a cron job runs to permanently delete canceled appointments. I implemented the cron job using PgAgent.

## Doctor employee

A doctor can view only the patients who have had an appointment with them. They do not have access to patients who have never visited them. A doctor can create, view, update patients medical record. When a patient comes to their very first appointment, the doctor asks a few general questions:

1. What vaccines have you received?
2. Do you have any chronic illnesses?
3. Do you have any allergies?
4. Are you taking any medication?
This answers are recorded in the system and will never be asked again. Patient can request change of some information (for example if he gets vaccinated or starts/stops using some medication).

## Chatting 
This system also supports chating between employees. When a user starts a conversation, a unique string is generated for both participants. This string is called connection string it ensures that each chat remains distinct from others. Once the string is created, a connection is established, allowing users to communicate in real time. Every message is stored in the database to ensure persistence. When retrieving messages from a specific chat, they are sorted in ascending order, displaying them chronologically—similar to messaging apps like Facebook or Instagram.

## Problems and Solutions

Authentication and Authorization has alot of problems, first problem is xss (cross site scripting) where an attacker can execute malitious javascript to localstorage and obtain users JWT, then he can make calls to server and create a lot of problems. Another problem is logging out, simply deleting JWT will logg out user or it will only seem like he logged out, in reallity his JWT will still be valid and if someone can obtain it trough some other way he can use it as long as that jwt is not expired. To solve this problem we can use an access token and a refresh token. The access token should be short-lived, while the refresh token is long-lived. Every time the access token expires, the refresh token can be used to generate a new one, keeping the user logged in. If only the refresh token is stored in localStorage, an attacker (even if they manage to obtain it) won't be able to do much, since the refresh token alone cannot be used to directly access protected resources. When a user logs out, we can store their JWT in a database, blacklisting it. However, this approach goes against the stateless nature of JWTs, as it introduces server-side storage and tracking of tokens. So, you're wondering what the best way to implement authentication and authorization is? The truth is, there’s no "BEST" solution. Every approach has its pros and cons, but one of the most secure and widely used methods today is generating a JWT and storing it in an HttpOnly cookie with the SameSite attribute set to Strict (or Lax by default). When a user logs in, we check if they have a valid token in their request headers—if they do, they’re authenticated; if not, they’re not logged in. This approach keeps authentication secure by avoiding client side storage of sensitive data. Of course, in real-world projects, we often rely on third-party services that offer a higher level of security and safety. 

## Future Implementations 

I want to allow patients to log in to the system, but only if they have had at least one appointment. This way, once they log in, they will be able to review the hospital and share their experience. Doctors should also be able to upload X-rays or any other medical documents related to a patient (this can be solved by using AWS S3). Receptionists should have the ability to download a patient's medical record as a PDF or print it out upon the patient's request. 


# Conclusion

This project really challenged me to think outside the box. Although my initial implementations weren’t perfect, researching various problems and revisiting concepts pushed me to learn and grow, not just as a developer but also as a problem solver. My motto in programming is "Learn it the hard way." While it's easy to rely on existing libraries in real projects, doing things manually helps us understand how everything works "under the hood". 
