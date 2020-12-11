# ChgSqlServerToMySql
自用SqlServer语句转为MySQL，就目前工作需要，将特定Sqlserver语句一键转为MySQL语句，可批量。

由于是自用，所以只是针对目前工作上出现的情况，就固定格式来转换，其他格式直接报错。

## 例子

### 不带注释
Sqlserver
```sql
if not exists(select 1 FROM BM_SF where BM0000='01')
INSERT INTO BM_SF (BM0000, MC0000, PARENTBM, GRADE, PYDM , ENDMARK, enus, zhtw, OtherLanguage, Disable)
 VALUES ('01', '足球', '', 1, '' , 1, 'FootBall', '足球', '', 0)
```

转为
```sql
INSERT INTO BM_SF (BM0000, MC0000, PARENTBM, GRADE, PYDM , ENDMARK, enus, zhtw, OtherLanguage, Disable)
 SELECT '01', '足球', '', 1, '' , 1, 'FootBall', '足球', '', 0
FROM DUAL WHERE NOT EXISTS (select 1 FROM BM_SF where BM0000='01');
```

### 带注释
Sqlserver
```sql
--增加足球编码分类--
if not exists(select 1 FROM BM_SF where BM0000='01')
INSERT INTO BM_SF (BM0000, MC0000, PARENTBM, GRADE, PYDM , ENDMARK, enus, zhtw, OtherLanguage, Disable)
 VALUES ('01', '足球', '', 1, '' , 1, 'FootBall', '足球', '', 0)
```

转为
```sql
-- 增加足球编码分类--
INSERT INTO BM_SF (BM0000, MC0000, PARENTBM, GRADE, PYDM , ENDMARK, enus, zhtw, OtherLanguage, Disable)
 SELECT '01', '足球', '', 1, '' , 1, 'FootBall', '足球', '', 0
FROM DUAL WHERE NOT EXISTS (select 1 FROM BM_SF where BM0000='01');
```
