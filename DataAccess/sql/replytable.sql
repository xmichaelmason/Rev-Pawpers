--Replies Table w/references--
CREATE table Reply (
	reply_id int identity (1,1) primary key,
	reply_message varchar (250) not null,
	reply_timestamp DATETIME,
	profile_id int FOREIGN KEY REFERENCES profile (profile_id) on delete cascade,
	topic_id int FOREIGN KEY REFERENCES topic (topic_id) on delete cascade
);


--Replies Table--
--CREATE table Reply (
	reply_id int identity (1,1) primary key,
	reply_message varchar (250) not null,
	reply_timestamp DATETIME,
	profile_id int,
	topic_id int
);

--Drop table Reply;
--DELETE FROM Reply;
