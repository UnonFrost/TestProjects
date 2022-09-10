USE trigger_task
GO

CREATE TRIGGER dbo.trigger_2
ON orders_detail
FOR INSERT, UPDATE, DELETE
AS
BEGIN
  
IF EXISTS (SELECT 0 FROM inserted)
BEGIN
   IF EXISTS (SELECT 0 FROM deleted)
   BEGIN 

     DECLARE @id_update AS INT
  SELECT
    @id_update = ID
  FROM INSERTED

    DECLARE @id_order_update AS INT
    SELECT
    @id_order_update = ID_ORDER
  FROM INSERTED

  DECLARE @discont_update AS DECIMAL
  SELECT
    @discont_update = DISCOUNT
  FROM [ORDERS]
    WHERE ID = @id_order_update

    DECLARE @price_update AS DECIMAL
  SELECT
    @price_update = PRICE
  FROM INSERTED

    DECLARE @qty_update AS DECIMAL
  SELECT
    @qty_update = QTY
  FROM INSERTED


  UPDATE orders_detail
  SET STR_SUM = (((@discont_update / 100) + 1) * (@price_update * @qty_update))
  WHERE ID = @id_update

    DECLARE @amount_update AS DECIMAL
    SELECT @amount_update = SUM(STR_SUM) FROM orders_detail
      WHERE ID_ORDER = @id_order_update

      UPDATE orders
        SET AMOUNT = @amount_update
        WHERE ID = @id_order_update


  PRINT 'updated amount ';

   END ELSE
   BEGIN
      DECLARE @id_insert AS INT
  SELECT
    @id_insert = ID
  FROM INSERTED

    DECLARE @id_order_insert AS INT
    SELECT
    @id_order_insert = ID_ORDER
  FROM INSERTED

  DECLARE @discont_insert AS DECIMAL
  SELECT
    @discont_insert = DISCOUNT
  FROM [ORDERS]
    WHERE ID = @id_order_insert

    DECLARE @price_insert AS DECIMAL
  SELECT
    @price_insert = PRICE
  FROM INSERTED

    DECLARE @qty_insert AS DECIMAL
  SELECT
    @qty_insert = QTY
  FROM INSERTED


  UPDATE orders_detail
  SET STR_SUM = (((@discont_insert / 100) + 1) * (@price_insert * @qty_insert))
  WHERE ID = @id_insert
  DECLARE @amount_insert AS DECIMAL
    SELECT @amount_insert = SUM(STR_SUM) FROM orders_detail
      WHERE ID_ORDER = @id_order_insert

      UPDATE orders
        SET AMOUNT = @amount_insert
        WHERE ID = @id_order_insert


  PRINT 'updated amount ';
   END
END ELSE 
BEGIN
   DECLARE @delete_order_id AS INT
    SELECT @delete_order_id = ID_ORDER FROM deleted
DECLARE @amount_delete AS DECIMAL
    SELECT @amount_delete = SUM(STR_SUM) FROM orders_detail
      WHERE ID_ORDER = @delete_order_id

      UPDATE orders
        SET AMOUNT = @amount_delete
        WHERE ID = @delete_order_id


  PRINT 'updated amount ';
END 
END
GO

