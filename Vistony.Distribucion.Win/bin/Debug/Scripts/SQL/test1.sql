CREATE PROCEDURE SP_VIS_PERSON_POSITION(IN Rol VARCHAR(50))
AS
BEGIN

	SELECT T0."salesPrson" "CodEmp",
	T1."firstName" || ' ' || T1."lastName" "Empleado" 
	FROM HEM6 T0
	INNER JOIN OHEM T1 ON
	T0."empID" =  T1."empID"
	LEFT JOIN OHTY T3 ON T0."roleID"=T3."typeID"
	WHERE UPPER(T3."name")=UPPER(:Rol);

END;