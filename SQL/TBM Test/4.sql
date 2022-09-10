USE trigger_task
GO

CREATE TRIGGER dbo.trigger_4
ON orders_detail
FOR INSERT
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
  DECLARE @currentINDX AS INT
    SELECT
  @currentINDX = coalesce(MAX(orders_detail.IDX),0)
FROM dbo.orders_detail
WHERE orders_detail.ID_ORDER = @id_order
  
      UPDATE orders_detail
        SET IDX = @currentINDX + 1
        WHERE ID = @id
END
GO

