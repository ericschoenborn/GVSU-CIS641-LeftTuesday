# Overview
There are many groups that have a similar workflow that can be summed up in this need "I need these tasks done in this amount of time, signed off by this person". Though it is a common need that is easy to understand, the complexity makes it so not many suitable tools exist to fulfill this need and coordinate the information to everyone involved in a real time. LeftTuesday seeks to be the solution to this problem.

Any company with a hierarchical structure that aims to complete tasks will benefit from LeftTuesday. The largest advantage LeftTuesday has over the traditional document is that changes and progress can be viewed in real time.
# Software Requirements
- Must have a machine that can execute .net application
- Must have MySql installed
- Must have a way to send http requests
## Functional Requirements
### Concept
| ID | Requirement |
| :-------------: | :----------: |
| FR1 | Sending a valid create request to the Concept resource shall create a new Concept. |
| FR2 | Sending a get request with a valid ID to the Concept resource shall return the specified Concept. |
| FR3 | Sending a valid request request to the Concept resource shall return all Concepts. |
| FR4 | Sending a delete request with a valid ID to the Concept resource shall delete the specified Concept. |
| FR5 | Sending a update request with a valid ID to the Concept resource shall update the specified Concept. |
### Task
| ID | Requirement |
| :-------------: | :----------: |
| FR6 | Sending a valid create request to the Task resource shall create a new Task. |
| FR7 | Sending a get request with a valid ID to the Task resource shall return the specified Task. |
| FR8 | Sending a valid request request to the Task resource shall return all Task. |
| FR9 | Sending a delete request with a valid ID to the Task resource shall delete the specified Task. |
| FR10 | Sending a update request with a valid ID to the Task resource shall update the specified Task. |
### Content
| ID | Requirement |
| :-------------: | :----------: |
| FR11 | Sending a valid create request to the Content resource shall create a new Content. |
| FR12 | Sending a get request with a valid ID to the Content resource shall return the specified Content. |
| FR13 | Sending a valid request request to the Content resource shall return all Content. |
| FR14 | Sending a delete request with a valid ID to the Content resource shall delete the specified Content. |
| FR15 | Sending a update request with a valid ID to the Content resource shall update the specified Content. |
### User
| ID | Requirement |
| :-------------: | :----------: |
| FR16 | Sending a valid create request to the User resource shall create a new User. |
| FR17 | Sending a get request with a valid ID to the User resource shall return the specified User. |
| FR18 | Sending a valid request request to the User resource shall return all User. |
| FR19 | Sending a delete request with a valid ID to the User resource shall delete the specified User. |
| FR20 | Sending a update request with a valid ID to the User resource shall update the specified User. |
### Session
| ID | Requirement |
| :-------------: | :----------: |
| FR21 | Sending a valid create request to the Session resource shall create a new Session. |
| FR22 | Sending a get request with a valid ID to the Session resource shall return the specified Session. |
| FR23 | Sending a valid request request to the Session resource shall return all Session. |
| FR24 | Sending a delete request with a valid ID to the Session resource shall delete the specified Session. |
| FR25 | Sending a update request with a valid ID to the Session resource shall update the specified Session. |
## Non-Functional Requirements
### Concept
| ID | Requirement |
| :-------------: | :----------: |
| NFR1 | There exists a data object structured in the sql normal from for storing Concepts. |
| NFR2 | There exists a data object structured in a human readable way for displaying Concepts. |
| NFR3 | All values in a request shall be validated. |
| NFR4 | All values in a request shall be sanitized. |
### Task
| ID | Requirement |
| :-------------: | :----------: |
| NFR5 | There exists a data object structured in the sql normal from for storing Task. |
| NFR6 | There exists a data object structured in a human readable way for displaying Task. |
| NFR7 | All values in a request shall be validated. |
| NFR8 | All values in a request shall be sanitized. |
### Content
| ID | Requirement |
| :-------------: | :----------: |
| NFR9 | There exists a data object stuctured in the sql normal from for storing Content. |
| NFR10 | There exists a data object structured in a human readable way for displaying Content. |
| NFR11 | All values in a request shall be validated. |
| NFR12 | All values in a request shall be sanitized. |
### User
| ID | Requirement |
| :-------------: | :----------: |
| NFR13 | There exists a data object stuctured in the sql normal from for storing User. |
| NFR14 | There exists a data object structured in a human readable way for displaying User. |
| NFR15 | All values in a request shall be validated. |
| NFR16 | All values in a request shall be sanitized. |
### Session
| ID | Requirement |
| :-------------: | :----------: |
| NFR17 | There exists a data object stuctured in the sql normal from for storing Session. |
| NFR18 | There exists a data object structured in a human readable way for displaying Session. |
| NFR19 | All values in a request shall be validated. |
| NFR20 | All values in a request shall be sanitized. |
### Code
| ID | Requirement |
| :-------------: | :----------: |
| NFR21 | Data object shall be persisted in a data store. |
| NFR22 | Requests shall be consumed by a http style API. |
| NFR23 | Code will be organized in Concomption, Work, and Datastore layers to increase code maintainability and adaptability. |
| NFR24 | Code layers will rely on Dependency Injection to increase code maintainability and adaptability. |
| NFR25 | Each resource will have its own class per layer to increase code maintainability and adaptability. |
# Change management plan
Before making any changes unit tests will need to be made to cover the code. The first thing that should be added to this application is to sanitize incoming data. Due to a scope change no sanitation methods have been added. Next cascading deletes need to be added. At this point in time, deletes only affect the resource given. Finally the authentication is very minimal and should be updated to be more effective.

As it stands this application is very proficient in storing data and the code was written with maintainability in mind. Going forward, I highly suggest the the code continues to maintain the Controller, Service, Repository model. Any changes to the data store should continue to follow the Normal forms standard.

This application has much potential to cover even more types of jobs and have specified rolls added for unique rules. As it stands, this API can be placed behind any custom frontend that will transform this generic tree manager into a specific organization job manager.
# Traceability links
Here are the artifacts used to create this application
## Use Case Diagram Traceability
| Artifact ID | Artifact Name | Requirement ID |
| :-------------: | :----------: | :----------: |
| 01| ClassDiagrams1 | FR1-10 |
| … | … | … |
## Class Diagram Traceability
| Artifact Name | Requirement ID |
| :-------------: |:----------: |
|ClassDiagram+ConceptModel.png| NFR1-5|
| … | … | … |
## Activity Diagram Traceability
| Artifact ID | Artifact Name | Requirement ID |
| :-------------: | :----------: | :----------: |
| 01 | ActivityDiagram1.png | FR1-15 |
| … | … | … |
# Software Artifacts
Here are the above mentions resources
* [ActivityDiagram1.png](https://github.com/ericschoenborn/GVSU-CIS641-LeftTuesday/blob/master/docs/Diagrams/ActivityDiagram1.png)
*[ClassDiagram+ConceptModel.png](https://github.com/ericschoenborn/GVSU-CIS641-LeftTuesday/blob/master/docs/Diagrams/ClassDiagram%2BConceptModel.png)
*[UseCaseses1](https://github.com/ericschoenborn/GVSU-CIS641-LeftTuesday/blob/master/docs/Diagrams/UseCases1.png)

