IF NOT EXISTS 
    (   SELECT  1
        FROM    Balansas 
        WHERE   Menesis = 'Sausis' 
        AND     Suma = 500
    )
    BEGIN
        INSERT Balansas VALUES (1, 'Sausis', 500) 
    END;