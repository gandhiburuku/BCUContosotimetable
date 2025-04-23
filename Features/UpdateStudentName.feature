Feature: Update Student Name
 
  As an admin or teacher
  I want to update a student's name via the API
  So that the new name is reflected in the web-frontend system

  Scenario: Successfully update the name of an existing student
    Given a student exists with ID '<Student Id>'
    When I send a PUT request to update their name to '<Student Name>'
    Then the API should return a successful response
    And the response body should contain the updated name '<Student Name>'
    When I open the student details page for student with ID '1' in the web application
    Then the student name should be displayed as '<Student Name>'
Examples: 
| Student Id | Student Name |
| 1          | Test Name    |