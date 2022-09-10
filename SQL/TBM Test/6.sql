USE trigger_task
GO

CREATE TRIGGER dbo.trigger_6
ON orders_detail
AFTER UPDATE
AS
BEGIN
  DECLARE @id AS INT
  SELECT
    @id = ID
  FROM INSERTED

    DECLARE @id_order AS INT
    SELECT
    @id_order = ID_ORDER
  FROM INSERTED

  DECLARE @discont AS DECIMAL
  SELECT
    @discont = DISCOUNT
  FROM [ORDERS]
    WHERE ID = @id_order

    DECLARE @price AS DECIMAL
  SELECT
    @price = PRICE
  FROM INSERTED

    DECLARE @qty AS DECIMAL
  SELECT
    @qty = QTY
  FROM INSERTED


  UPDATE orders_detail
  SET STR_SUM = (((@discont / 100) + 1) * (@price * @qty))
  WHERE ID = @id
  PRINT 'updated STR_SUM ';

END
GO