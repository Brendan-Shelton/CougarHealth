INSERT INTO [dbo].[Service] (
	[PercentCoverage], 
	[Category], 
	[Name], 
	[MaxPayRate], 
	[InNetworkMax], 
	[InsurancePlanId], 
	[RequiredCopayment]
)
VALUES 
(
	0.9,
	'Hospital',
	'Inpatient', 
	'Day', 
	2000.0,
	5,
	400.0	
),
(
	0.9,
	'Hospital', 
	'Inpatient (Behavioral Health',
	'Day',
	1500.0,
	5,
	400.0 
),
(
	1,
	'Hospital', 
	'Emergency Room', 
	'PCY', 
	1000.0,
	5,
	250.0
),
(
	0.9,
	'Hospital', 
	'Outpatient Surgery', 
	'PCY', 
	4000.0, 
	5,
	250.0
), 
(
	0.9,
	'Hospital',
	'Diagnostic Lab and xray',
	'PCY', 
	500.0,
	5, 
	0
), 
( 
	0.9,
	'Physician', 
	'Office Visit', 
	'PCY', 
	150.0,
	5,
	0
),
(
	0.90,
	'Physician', 
	'Specialist Visit', 
	'PCY', 
	300.0, 
	5, 
	0		
), 
(
	1,
	'Physician', 
	'Preventive Services', 
	'PCY', 
	25.0, 
	5, 
	0		
),
(
	1,
	'Physician', 
	'Baby Services', 
	'PCY', 
	300.0, 
	5, 
	0		
),
(
	0.8,
	'Other', 
	'Durable Medical Equipment', 
	'PCY', 
	300.0, 
	5, 
	0		
),
(
	0.9,
	'Other', 
	'Nursing Facility', 
	'Day', 
	250.0, 
	5, 
	0		
), 
(
	0.9,
	'Other', 
	'Physical Therapy', 
	'Session', 
	100.0, 
	5, 
	0		
),
(
	0.9,
	'Hospital', 
	'Inpatient', 
	'Day', 
	2000.0, 
	6, 
	300.0
),
(
	1,
	'Hospital', 
	'Inpatient (Behavioral Health)', 
	'Day', 
	1500.0, 
	6, 
	300.0
),
(
	1,
	'Hospital', 
	'Emergency Room', 
	'PCY', 
	1000.0, 
	6, 
	250.0
),
(
	1,
	'Hospital', 
	'Outpatient Surgery', 
	'PCY', 
	4000.0, 
	6, 
	250.0
),
(
	1,
	'Hospital', 
	'Diagnostic Lab and x-ray', 
	'PCY', 
	500.0, 
	6, 
	0
),
(
	1,
	'Physician', 
	'Office Visit', 
	'PCY', 
	150.0, 
	6, 
	20
),
(
	1,
	'Physician', 
	'Specialist Visit', 
	'PCY', 
	300.0, 
	6, 
	30
),
(
	1,
	'Physician', 
	'Preventive Services', 
	'PCY', 
	25.0, 
	6, 
	0
),
(
	1,
	'Physician', 
	'Baby Services', 
	'PCY', 
	300.0, 
	6, 
	0
),
(
	0.8,
	'Other', 
	'Durable Medical Equipment', 
	'PCY', 
	300.0, 
	6, 
	0
),
(
	1.0,
	'Other', 
	'Nursing Facility', 
	'Day', 
	250.0, 
	6, 
	0
),
(
	1.0,
	'Other', 
	'Physical Therapy', 
	'Session', 
	100.0, 
	6, 
	30.0
)