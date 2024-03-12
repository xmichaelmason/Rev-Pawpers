Create Table Profile
(
	profile_id                INT IDENTITY(1,1) PRIMARY KEY,
	profile_name              VARCHAR(32) NOT NULL,
	profile_streetaddress     VARCHAR(32) NOT NULL,
	profile_city		      VARCHAR(32) NOT NULL,
	profile_state		      VARCHAR(32) NOT NULL,
	profile_zipcode		      VARCHAR(9) NOT NULL,
	profile_age               INT NOT NULL,
	profile_homephone         VARCHAR(9) NOT NULL,
	profile_personalphone     VARCHAR(9),
	profile_email             VARCHAR(32) NOT NULL,
	profile_occupation        VARCHAR(32),
	profile_spousename        VARCHAR(32),
	profile_children          INT NOT NULL,
	profile_dwellingid        INT NOT NULL,
	profile_hasyard           INT NOT NULL,
	profile_landlordname      VARCHAR(32),
	profile_landlordphone     VARCHAR(9),
	profile_otherpetname      VARCHAR(32),
	profile_otherpetbreed     VARCHAR(32),
	profile_otherpetsex       VARCHAR(9),
	profile_otherpetage       INT,
	profile_familyallergies   INT NOT NULL,
	profile_responsiblefordog VARCHAR(32) NOT NULL,
	profile_adoptionreason    VARCHAR(32) NOT NULL,
	profile_dogsleepat        VARCHAR(32) NOT NULL,
	profile_dogaggresive      VARCHAR(32) NOT NULL,
	profile_medfordog         VARCHAR(32) NOT NULL,
	profile_nocaredog         VARCHAR(32) NOT NULL,
	
	CONSTRAINT pro_dwe_FK FOREIGN KEY(profile_dwellingid)
			REFERENCES Dwelling(dwelling_id),
	
);

Create Table Dwelling
(
	dwelling_id               INT IDENTITY(1,1) PRIMARY KEY,
	dwelling_type             VARCHAR(32) NOT NULL,

);