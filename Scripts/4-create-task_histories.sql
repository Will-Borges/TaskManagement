CREATE TABLE task_histories (
    id SERIAL PRIMARY KEY,
    task_id INT NOT NULL,
    field_name VARCHAR(255) NOT NULL,
    old_value VARCHAR(255) NOT NULL,
    new_value VARCHAR(255) NOT NULL,
    changed_at TIMESTAMP NOT NULL,
    changed_by INT NOT NULL,
    FOREIGN KEY (task_id) REFERENCES tasks(id) ON DELETE CASCADE,  -- Assumindo que existe uma tabela tasks com uma chave primária chamada id
    FOREIGN KEY (changed_by) REFERENCES users(id)  -- Assumindo que existe uma tabela users com uma chave primária chamada id
);