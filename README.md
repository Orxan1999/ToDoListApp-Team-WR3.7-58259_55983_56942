The Todolist app is a task management application designed to help users organize their daily activities efficiently.

Documentation:

Functional Requirements:

Task Management
•	Users can create new tasks.
•	Users can edit existing tasks.
•	Users can delete tasks.
•	Users can mark tasks as completed.
 
User Interface
•	The app has a user-friendly interface that allows easy navigation.
•	Tasks are displayed in a list format with clear indications of their status (e.g., completed, pending).
•	Users can view tasks by status, or deadline.

Sort
•	Users can sort tasks based on status, title, and deadline.
Non-Functional Requirements

Performance
•	The app loads and responds to user actions within 2 seconds.

Usability
•	The app is intuitive and easy to use for users

Compatibility
•	The app is compatible with major web browsers (e.g., Chrome, Firefox, Safari).



Classes:
Common class in a ToDoListApp include:
•	Task

Attributes:
Task
•	Id, Title, Description, Deadline, Status, CreatedOn, CompletedOn

Methods:
Task
•	Create(), Update(), Delete(), Detail()



Implementation (Business Logic Layer):

Core Functionality:
•	Task Creation: Implement logic to add a new task to the database.
•	Task Deletion: Implement logic to remove a task from the database.
•	Task Updating: Implement logic to update the details of an existing task.
•	Task Sorting: Implement logic to sort tasks based on various criteria (e.g., due date, priority).

Architecture:
•	Use the Model-View-Controller (MVC) architectural pattern to separate concerns.
o	Model: Represents the data and business logic.
o	View: Represents the user interface.
o	Controller: Handles user input, interacts with the model, and selects the view for response.

Integration:
•	The Controller will receive input from the presentation layer, process it using the business logic, and interact with the database layer to perform CRUD operations.






Implementation (Presentation Layer):

Framework:
•	Use ASP.NET Core MVC to develop the presentation layer.

User Interface:
•	Task List View: Display a list of tasks with options to view, edit, delete, and sort.
•	Task Detail View: Display details of a specific task with options to edit or delete.
•	Input Forms: Provide forms for creating and updating tasks.

User Experience:
•	Ensure the interface is user-friendly with intuitive navigation.
•	Implement responsive design to support various devices.
•	Include accessibility features to support users with disabilities.

Interaction:
•	Controllers in the presentation layer will handle user requests, invoke business logic, and return appropriate views.
•	Use AJAX for asynchronous updates to improve user experience.





Implementation (Database Layer):

Database Choice:
•	Use MSSQL as the database management system.

Schema Design:
•	Tables:
o	Tasks: Table to store task details.
	Columns: TaskID (Primary Key), Title, Description, Dadline, Status, CreatedOn, CompletedOn.


Data Operations:
•	Create: Insert new tasks into the Tasks table.
•	Read: Retrieve tasks from the Tasks table.
•	Update: Modify existing tasks in the Tasks table.
•	Delete: Remove tasks from the Tasks table.


In order to launch application you need download Visual Studio tool and install .Net Framework while launching Visual Studio.