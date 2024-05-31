CREATE TABLE ChessGames (
	game_id UNIQUEIDENTIFIER PRIMARY KEY,
	host_username VARCHAR(20) NOT NULL,
	guest_username VARCHAR(20),
	game_description VARCHAR(255),
	is_whites_turn BIT NOT NULL,
	board VARCHAR(64) NOT NULL
);

CREATE TABLE JoinRequests (
  	request_id UNIQUEIDENTIFIER PRIMARY KEY,
	game_id UNIQUEIDENTIFIER NOT NULL,
	FOREIGN KEY (game_id) REFERENCES ChessGames(game_id)
);