SELECT * FROM qingchen_171.wqtab order by idwqtab desc limit 0,40;

SELECT * FROM qingchen_171.wqtab where type='click' order by idwqtab desc limit 0,40;

'2013-06-29 16:44:12'

SELECT * FROM qingchen_171.wqtab where addtime > '2013-06-29' and type = 'click' and game = '%E4%BF%9D%E5%8D%AB%E9%92%93%E9%B1%BC%E5%B2%9B';

SELECT hour(addtime),count(*) FROM qingchen_171.wqtab where game='Trial Xtreme 2 HD' and addtime > '2013-06-29' and type = 'click' group by hour(addtime);

SELECT game,type,count(*),count(*)*0.3 amount FROM qingchen_171.wqtab where addtime > '2013-06-29 16:44:12' group by game,type;


SELECT game,type,count(*),count(*)*0.3 amount FROM qingchen_171.wqtab where addtime > '2013-06-29 16:44:12' group by game,type order by type,game;
