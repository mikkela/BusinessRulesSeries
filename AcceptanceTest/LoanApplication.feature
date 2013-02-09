Feature: LoanApplication
	In order to serve my master corretcly
	As a loan shark associate
	I want to be told if an applicant can get a loan and at what interest rate

@mytag
Scenario: Applicant is less than 18 years old
	Given I have entered 17 into the age field
	When I press submit
	Then the applicant is rejected
	And the reason is 'Because you are too young'

Scenario: Applicant is 18 years old
	Given I have entered 18 into the age field
	When I press submit
	Then the applicant is accepted
	And the interest rate is 25 %
	And the reason is 'Because you will party before you pay'

Scenario: Applicant is 25 years old
	Given I have entered 25 into the age field
	When I press submit
	Then the applicant is accepted
	And the interest rate is 25 %
	And the reason is 'Because you will party before you pay'

Scenario: Applicant is 26 years old
	Given I have entered 26 into the age field
	When I press submit
	Then the applicant is accepted
	And the interest rate is 15 %
	And the reason is 'Because you got family - we get security'

Scenario: Applicant is 65 years old
	Given I have entered 65 into the age field
	When I press submit
	Then the applicant is accepted
	And the interest rate is 15 %
	And the reason is 'Because you got family - we get security'

Scenario: Applicant is 66 years old
	Given I have entered 66 into the age field
	When I press submit
	Then the applicant is accepted
	And the interest rate is 20 %
	And the reason is 'Because you are old'