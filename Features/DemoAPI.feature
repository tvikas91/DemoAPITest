Feature: DemoAPI	


Scenario: Get Scenario for DEemo API
Given URL for API is 'api/users?page=2'
And Create GET Request
When Execute the request
Then Status Code is 'OK'
And Response Content 

Scenario: Post Scenario for DEemo API
Given URL for API is 'api/users'
And Create POST request
And Payload is '..\..\DataSources\UserData.json'
When Execute the request
Then Status Code is 'Created'
And Response Content 
And Validate UserID is 'Vivek'

@Multiple
Scenario Outline:Post Multiple Users
Given URL for API is 'api/users'
And Create POST request
And Payload is <Payload>
When Execute the request
Then Status Code is 'Created'
And Response Content 


Examples: 
| Payload                           |
| '..\..\DataSources\UserDataII.json' |
| '..\..\DataSources\UserData.json' |
| '..\..\DataSources\UserDataIII.json' |

