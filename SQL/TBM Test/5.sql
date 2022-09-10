CREATE TRIGGER dbo.trigger_5
ON orders
FOR INSERT, UPDATE
AS
BEGIN
  DECLARE @id_update AS INT
  SELECT
    @id_update = ID
  FROM INSERTED
  
    DECLARE @discount AS INT
  SELECT
    @discount = DISCOUNT
  FROM INSERTED
  
    IF (@discount > 100 AND @discount < 0)

BEGIN
PRINT 'ROLLBACK';
ROLLBACK TRAN
END
ELSE
PRINT 'updated';

END