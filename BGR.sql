Create DATABASE BoardgameRepo;

CREATE table Location(
    LID int IDENTITY,
    LocationName VARCHAR(30),
    Address VARCHAR(50),
    City VARCHAR(20),
    State varchar (20),
    CONSTRAINT PK_Location_ID 
    PRIMARY KEY (LID)
)
CREATE TABLE BoardGame(
    GID int IDENTITY,
    BGName VARCHAR(50),
    Genre VARCHAR(20),
    MaxPlayerCount int,
    MinPlayerCount INT
    CONSTRAINT PK_BoardGame_ID
    PRIMARY KEY(GID)
)

Create TABLE UserTable(
    UID INT IDENTITY,
    UserName VARCHAR(20),
    PASSWORD varchar(20),
    Email VARCHAR(30),
    DoB VARCHAR(30),
    LID int
    CONSTRAINT PK_User_ID
    PRIMARY KEY (UID)
    CONSTRAINT FK_Location_ID
    FOREIGN KEY (LID) REFERENCES LOCATION(LID)
)
Alter TABLE
    UserTable
ALTER COLUMN
    Email VARCHAR(30) not NULL,
    DoB VARCHAR(30) not NULL,
    LID int not NULL
 

create TABLE UserCollection(
    UCID int,
    UID int,
    GID INT
    CONSTRAINT PK_UserCollection_ID
    PRIMARY KEY (UCID)
    CONSTRAINT FK_User_ID
    FOREIGN KEY (UID) REFERENCES UserTable(UID),
    CONSTRAINT FK_BoardGame_ID
    FOREIGN KEY (GID) REFERENCES BoardGame(GID)
)
create TABLE Meeting(
    MID int,
    LID int,
    GID INT
    CONSTRAINT PK_Meeting_ID
    PRIMARY KEY (MID)
    CONSTRAINT FK_MeetingUser_ID
    FOREIGN KEY (LID) REFERENCES Location(LID),
    CONSTRAINT FK_MeetingBoardGame_ID
    FOREIGN KEY (GID) REFERENCES BoardGame(GID)
)
create TABLE UserMeeting(
    UMID int,
    UID int,
    MID INT
    CONSTRAINT PK_UserMeeting_ID
    PRIMARY KEY (UMID)
    CONSTRAINT FK_UMMeeting_ID
    FOREIGN KEY (UID) REFERENCES UserTable(UID),
    CONSTRAINT FK_UMBoardGame_ID
    FOREIGN KEY (MID) REFERENCES Meeting(MID)
)


