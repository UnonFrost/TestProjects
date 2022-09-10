USE trigger_task
GO

CREATE TRIGGER dbo.trigger_1
ON orders
AFTER UPDATE
AS
BEGIN
  DECLARE @id AS INT
  SELECT
    @id = ID
  FROM INSERTED

  DECLARE @discont AS DECIMAL
  SELECT
    @discont = DISCOUNT
  FROM INSERTED

  UPDATE orders_detail
  SET STR_SUM = (((@discont / 100) + 1) * (PRICE * QTY))
  WHERE ID_ORDER = @id
  PRINT 'updated STR_SUM ' + CONVERT(VARCHAR(MAX), @discont);

END
GO