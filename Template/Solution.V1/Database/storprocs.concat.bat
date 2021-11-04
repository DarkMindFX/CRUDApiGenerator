for /r "\storprocs" %F in (*.sql) do @type "%F" >> CreateAllStorProcs.sql
