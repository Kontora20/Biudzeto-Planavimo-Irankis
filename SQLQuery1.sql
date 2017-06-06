SELECT A.SumCol1 - B.SumCol2 as Total
FROM (SELECT SUM(Suma) SumCol1 from Iplaukos WHERE VartotojoID = 1 and Menesis = 'Sausis') A CROSS JOIN 
(SELECT SUM(Suma) SumCol2 from Islaidos WHERE VartotojoID = 1 and Menesis = 'Sausis') B
INSERT INTO Balansas VALUES (1, 'Sausis', )