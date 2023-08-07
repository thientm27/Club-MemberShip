INSERT INTO [dbo].[ActivityStatus] ([Id], [Status])
VALUES
  ('Preparing', 'Preparing'),
  ('Ongoing', 'Ongoing'),
  ('Finished', 'Finished');

INSERT INTO [ClubMembership].[dbo].[Club] ([Id], [Code], [Name], [Logo], [ShortDecription], [LongDecription], [DateOfEstablishment], [Status])
VALUES 
(1, 'FVC', 'FPT Vovinam Club', '#', 'Sports Club', 'A club for Vovinam enthusiasts', '2020-01-01', 1),
(2, 'FFC', 'FFC Football Club', '#', 'Sports Club', 'A club for Football', '2019-01-01', 1),
(3, 'FCC', 'FPT Chess Club', '#', 'Sports Club', 'A club for Chess', '2018-01-01', 1),
(4, 'FVC', 'FPTU HCM Basketball Club', '#', 'Sports Club', 'A club for Basketball', '2020-01-01', 1),
(5, 'FTI', 'FPT Traditional Instruments – Old But Not Faded', '#', 'Musical Club', 'A club for Traditional Instruments lover in FPT', '2015-01-01', 1),
(6, 'FPC', 'Photography Club', 'logo2.png', 'Photography Club Short Description', 'Photography Club Long Description', '2019-05-15', 1),
(7, 'FMC', 'Music Club', 'logo3.png', 'Music Club Short Description', 'Music Club Long Description', '2018-09-30', 1);


INSERT INTO [dbo].[ClubBoard] ([Id], [Name])
VALUES
  (1, 'Executive Board'),
  (2, 'Logistics Board'),
  (3, 'Media Board'),
  (4, 'Technical Board');

  INSERT INTO [dbo].[ClubActivity] ([Id], [ClubId], [StatusId], [StartDay], [EndDay], [CreateDay])
VALUES
  (1, 1, 'Preparing', '2023-08-15', '2023-08-20', '2023-08-01'),
  (2, 1, 'Ongoing', '2023-08-01', '2023-08-30', '2023-08-05'),
  (3, 2, 'Preparing', '2023-09-01', '2023-09-05', '2023-08-25'),
  (4, 2, 'Finished', '2022-09-10', '2022-09-15', '2022-09-01');

-- Insert data into [dbo].[Grade] table
INSERT INTO [dbo].[Grade] ([Id], [GradeYear])
VALUES
  (1, '2013-01-01'),
  (2, '2014-01-01'),
  (3, '2015-01-01'),
  (4, '2016-01-01'),
  (5, '2017-01-01'),
  (6, '2018-01-01'), 
  (7, '2019-01-01'),
  (8, '2020-01-01'),  
  (9, '2021-01-01'), -- Changed from 9 to 10, assuming it should be 10 for the year 2022
  (10, '2022-01-01'); -- Added a new entry for the year 2022


 INSERT INTO [dbo].[Major] ([Id], [Name], [Detail])
VALUES
  (1, 'Computer Science', 'Computer Science Major'),
  (2, 'Business Administration', 'Business Administration Major'),
  (3, 'Mechanical Engineering', 'Mechanical Engineering Major'),
  (4, 'Software Engineering', 'Software Engineering Major');

-- Insert data into [dbo].[Student] table
INSERT INTO [dbo].[Student] ([Id], [Name], [Address], [MajorId], [GradeId], [DateOfBirth], [Status])
VALUES
  ('STU001', 'John Smith', '123 Main St', 1, 1, '2000-05-10', 1),
  ('STU002', 'Emily Johnson', '456 Elm St', 2, 1, '1999-11-25', 1),
  ('STU003', 'Michael Lee', '789 Oak St', 1, 2, '2001-02-18', 1),
  ('STU004', 'Sophia Davis', '987 Maple St', 3, 2, '2002-09-30', 1); -- Changed Status value from 0 to 1 for consistency (assuming active students)


-- Insert data into [dbo].[Membership] table
INSERT INTO [dbo].[Membership] ([StudentId], [ClubId], [Id], [JoinDate], [QuitDate], [NickName], [Status])
VALUES
  ('STU001', 1, 1, '2023-01-01', NULL, 'JK', 1),
  ('STU002', 1, 2, '2023-01-15', NULL, 'Dek', 1),
  ('STU003', 2, 3, '2023-02-01', '2023-08-31', 'Smirt', 0),
  ('STU004', 2, 4, '2023-02-15', NULL, 'Mink', 1); -- Changed Status value from 0 to 1 for consistency (assuming active memberships)


INSERT INTO [dbo].[Participant] ([MembershipId], [ClubActivityId])
VALUES
  (1, 1),
  (2, 1),
  (2, 2),
  (3, 3),
  (4, 4);


 INSERT INTO [dbo].[MemberRole] ([MembershipId], [ClubBoardId], [StartDay], [EndDay])
VALUES
  (1, 1, '2023-01-01', '2023-12-31'),
  (2, 2, '2023-02-15', '2023-12-31'),
  (3, 3, '2023-03-01', '2023-12-31'),
  (4, 4, '2023-04-01', '2023-12-31');

