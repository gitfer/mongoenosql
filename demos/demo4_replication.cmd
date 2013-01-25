# Creare le folder C:\MongoDB\data\rs1 C:\MongoDB\data\rs2 C:\MongoDB\data\rs3

C:\MongoDB\bin\mongod.exe --replSet myreplicaset --logpath "C:\MongoDB\logs\1.log" --logappend --dbpath "C:\MongoDB\data\rs1" --port 27017
C:\MongoDB\bin\mongod.exe --replSet myreplicaset --logpath "C:\MongoDB\logs\2.log" --logappend --dbpath "C:\MongoDB\data\rs2" --port 27018
C:\MongoDB\bin\mongod.exe --replSet myreplicaset --logpath "C:\MongoDB\Logs\3.log" --logappend --dbpath "C:\MongoDB\data\rs3" --port 27019
