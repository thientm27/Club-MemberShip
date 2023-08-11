USE [ClubMembership]

-- Delete data from each table
DELETE FROM [dbo].[Participant];
DELETE FROM [dbo].[MemberRole];
DELETE FROM [dbo].[Membership];
DELETE FROM [dbo].[ClubActivity];
DELETE FROM [dbo].[ClubBoard];
DELETE FROM [dbo].[Student];
DELETE FROM [dbo].[Major];
DELETE FROM [dbo].[Grade];
DELETE FROM [dbo].[Club];

-- Insert data into [dbo].[Club] table
INSERT INTO [dbo].[Club] ([Id], [Code], [Name], [Logo], [ShortDecription], [LongDecription], [DateOfEstablishment], [Status])
VALUES 
  (1, 'FVC', 'FPT Vovinam Club', '#', 'Sports Club', 'A club for Vovinam enthusiasts', '2020-01-01', 1),
  (2, 'FFC', 'FFC Football Club', '#', 'Sports Club', 'A club for Football', '2019-01-01', 1),
  (3, 'FCC', 'FPT Chess Club', '#', 'Sports Club', 'A club for Chess', '2018-01-01', 1),
  (4, 'FHBC', 'FPTU HCM Basketball Club', '#', 'Sports Club', 'A club for Basketball', '2020-01-01', 1), -- Corrected Code
  (5, 'FTI', 'FPT Traditional Instruments – Old But Not Faded', '#', 'Musical Club', 'A club for Traditional Instruments lovers in FPT', '2015-01-01', 1), -- Corrected Description
  (6, 'FPC', 'Photography Club', 'logo2.png', 'Photography Club Short Description', 'Photography Club Long Description', '2019-05-15', 1),
  (7, 'FMC', 'Music Club', 'logo3.png', 'Music Club Short Description', 'Music Club Long Description', '2018-09-30', 1);

-- Insert data into [dbo].[ClubBoard] table
INSERT INTO [dbo].[ClubBoard] ([Id], [ClubId], [Name], [ShortDecription], [LongDecription], [Status])
VALUES
  -- Club 1: FPT Vovinam Club
  (1, 1, 'Executive Board', 'Executive Board Short Description', 'Executive Board Long Description', 1),
  (2, 1, 'Logistics Board', 'Logistics Board Short Description', 'Logistics Board Long Description', 1),
  (3, 1, 'Media Board', 'Media Board Short Description', 'Media Board Long Description', 1),
  (4, 1, 'Technical Board', 'Technical Board Short Description', 'Technical Board Long Description', 1),
  
  -- Club 2: FFC Football Club
  (5, 2, 'Management Board', 'Management Board Short Description', 'Management Board Long Description', 1),
  (6, 2, 'Players Board', 'Players Board Short Description', 'Players Board Long Description', 1),
  
  -- Club 3: FPT Chess Club
  (7, 3, 'Organizing Board', 'Organizing Board Short Description', 'Organizing Board Long Description', 1),
  (8, 3, 'Participants Board', 'Participants Board Short Description', 'Participants Board Long Description', 1),

  -- Club 4: FPTU HCM Basketball Club
  (9, 4, 'Leadership Board', 'Leadership Board Short Description', 'Leadership Board Long Description', 1),
  (10, 4, 'Players Board', 'Players Board Short Description', 'Players Board Long Description', 1),

  -- Club 5: FPT Traditional Instruments – Old But Not Faded
  (11, 5, 'Traditional Music Board', 'Traditional Music Board Short Description', 'Traditional Music Board Long Description', 1),
  (12, 5, 'Instruments Board', 'Instruments Board Short Description', 'Instruments Board Long Description', 1),
  
  -- Club 6: Photography Club
  (13, 6, 'Admin Board', 'Admin Board Short Description', 'Admin Board Long Description', 1),
  (14, 6, 'Photographers Board', 'Photographers Board Short Description', 'Photographers Board Long Description', 1),
  
  -- Club 7: Music Club
  (15, 7, 'Core Board', 'Core Board Short Description', 'Core Board Long Description', 1),
  (16, 7, 'Members Board', 'Members Board Short Description', 'Members Board Long Description', 1);


-- Insert data into [dbo].[ClubActivity] table
INSERT INTO [dbo].[ClubActivity] ([Id], [ClubId], [StartDay], [EndDay], [CreateDay],[Status], [TimeLine])
VALUES
  (1, 1, '2023-08-15', '2023-08-20', '2023-08-01', 0,1),
  (2, 1, '2023-08-01', '2023-08-30', '2023-08-05', 1,1),
  (3, 2,  '2023-09-01', '2023-09-05', '2023-08-25', 1,1),
  (4, 2,  '2022-09-10', '2022-09-15', '2022-09-01', 1,1);


-- Insert data into [dbo].[Grade] table
INSERT INTO [dbo].[Grade] ([Id], [GradeYear], [GraduateYear], [ExpeiredYear], [Status])
VALUES
  (1, '2013-01-01', '2017-01-01', '2022-01-01', 1),
  (2, '2014-01-01', '2018-01-01', '2023-01-01', 1),
  (3, '2015-01-01', '2019-01-01', '2024-01-01', 1),
  (4, '2016-01-01', '2020-01-01', '2025-01-01', 1),
  (5, '2017-01-01', '2021-01-01', '2026-01-01', 1),
  (6, '2018-01-01', '2022-01-01', '2027-01-01', 1),
  (7, '2019-01-01', '2023-01-01', '2028-01-01', 1),
  (8, '2020-01-01', '2024-01-01', '2029-01-01', 1),
  (9, '2021-01-01', '2025-01-01', '2030-01-01', 1),
  (10, '2022-01-01', '2026-01-01', '2031-01-01', 1);


-- Insert data into [dbo].[Major] table
INSERT INTO [dbo].[Major] ([Id], [Code], [Name], [Detail], [Semeter], [Status])
VALUES
  (1, 'CS', 'Computer Science', 'Computer Science Major', 8, 1),
  (2, 'BA', 'Business Administration', 'Business Administration Major', 8, 1),
  (3, 'ME', 'Mechanical Engineering', 'Mechanical Engineering Major', 8, 1),
  (4, 'SE', 'Software Engineering', 'Software Engineering Major', 8, 1);

-- Insert data into [dbo].[Student] table
INSERT INTO [dbo].[Student] ([Id], [Code], [Name], [Address], [MajorId], [GradeId], [DateOfBirth], [Status])
VALUES
  (1, 'STU001', 'John Smith', '123 Main St', 1, 1, '2000-05-10', 1),
  (2, 'STU002', 'Emily Johnson', '456 Elm St', 2, 1, '1999-11-25', 1),
  (3, 'STU003', 'Michael Lee', '789 Oak St', 1, 2, '2001-02-18', 1),
  (4, 'STU004', 'Sophia Davis', '987 Maple St', 3, 2, '2002-09-30', 1);


-- Insert data into [dbo].[Membership] table
INSERT INTO [dbo].[Membership] ([StudentId], [ClubId], [Id], [JoinDate], [QuitDate], [NickName], [Status])
VALUES
  (1, 1, 1, '2023-01-01', NULL, 'JK', 1),
  (1, 1, 2, '2023-01-15', NULL, 'Dek', 1),
  (2, 2, 3, '2023-02-01', '2023-08-31', 'Smirt', 1),
  (2, 2, 4, '2023-02-15', NULL, 'Mink', 1);

-- Insert data into [dbo].[Participant] table
INSERT INTO [dbo].[Participant] ([MembershipId], [ClubActivityId], [JoinDate], [LeaveDate], [RegisterDate], [Status])
VALUES
  (1, 1, '2023-08-15', NULL, '2023-08-01', 1),
  (2, 1, '2023-08-01', NULL, '2023-08-05', 1),
  (2, 2, '2023-08-01', NULL, '2023-08-05', 1),
  (3, 3, '2023-09-01', NULL, '2023-08-25', 1),
  (4, 4, '2022-09-10', NULL, '2022-09-01', 1);

-- Insert data into [dbo].[MemberRole] table
INSERT INTO [dbo].[MemberRole] ([MembershipId], [ClubBoardId], [StartDay], [EndDay], [Status])
VALUES
  (1, 1, '2023-01-01', '2023-12-31', 1),
  (2, 2, '2023-02-15', '2023-12-31', 1),
  (3, 3, '2023-03-01', '2023-12-31', 1),
  (4, 4, '2023-04-01', '2023-12-31', 1);