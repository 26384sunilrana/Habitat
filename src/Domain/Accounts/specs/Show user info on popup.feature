﻿Feature: Show user info on popup
	

@NeedImplementation
Scenario: Account_Show user info on popup_UC1_Only email is shown 
	Given Habitat website is opened on Register page
	When Actor enters following data in to the register fields
	| Email            | Password | ConfirmPassword |
	| kov@sitecore.net | k        | k               |
	And Actor clicks Register button
	And Actor moves cursor over the User icon
	Then User info is shown on User popup
	| Email            |
	| kov@sitecore.net |

@NeedImplementation
Scenario: Account_Show user info on popup_UC2_Full user info is shown 
	Given User with following data is registered in Habitat
	| Email              | Password | ConfirmPassword |
	| kov10@sitecore.net | k        | k               |	
	When Actor moves cursor over the User icon
	And User clicks Edit Profile from drop-down menu 
	User inputs data in to the fields
	| Last Name | First Name | Phone number    |
	| Teltov    | Konstantin | +38(067)3333333 |
	And User selects <Swiming> from Interests drop-down list
	Then User info is shown on User popup
	| Email            | Name              |
	| kov@sitecore.net | Konstantin Teltov |


@NeedImplementation
Scenario: Account_Show user info on popup_UC2_User Name with special symbols 
	Given User with following data is registered in Habitat
	| Email              | Password | ConfirmPassword |
	| kov10@sitecore.net | k        | k               |	
	When Actor moves cursor over the User icon
	And User clicks Edit Profile from drop-down menu 
	User inputs data in to the fields
	| Last Name           | First Name              | Phone number    |
	| Teltov!@#$%^&?()-+* | KONSTANTIN!@#$%^&?()-+* | +38(067)3333333 |
	And User selects <Swiming> from Interests drop-down list
	Then User info is shown on User popup
	| Email            | Name              |
	| kov@sitecore.net | Konstantin Teltov |
