BEGIN;

CREATE TABLE IF NOT EXISTS users (
    id SERIAL PRIMARY KEY,           
    name VARCHAR(255) NOT NULL,     
    position VARCHAR(255) NOT NULL  
);

CREATE TABLE IF NOT EXISTS projects (
    id SERIAL PRIMARY KEY,          
    name VARCHAR(255) NOT NULL,     
    description TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS tasks (
    id SERIAL PRIMARY KEY,          
    title VARCHAR(255) NOT NULL,     
    description TEXT NOT NULL,      
    due_date TIMESTAMP NOT NULL,     
    status INT NOT NULL,     
    priority INT NOT NULL,  
    project_id INT,                 
    FOREIGN KEY (project_id) 
        REFERENCES projects(id)
        ON DELETE SET NULL
        ON UPDATE CASCADE
);

CREATE TABLE IF NOT EXISTS project_user (
	id SERIAL PRIMARY KEY,
    user_id INT NOT NULL,           
    project_id INT NOT NULL,       
    FOREIGN KEY (user_id) 
        REFERENCES users(id)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
    FOREIGN KEY (project_id) 
        REFERENCES projects(id)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

COMMIT;
