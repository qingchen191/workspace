SELECT * FROM qingchen_171.wqtab order by idwqtab desc limit 0,40;

SELECT * FROM qingchen_171.wqtab where type='click' order by idwqtab desc limit 0,40;

'2013-06-29 16:44:12'

SELECT * FROM qingchen_171.wqtab where addtime > '2013-06-29' and type = 'click' and game = '%E4%BF%9D%E5%8D%AB%E9%92%93%E9%B1%BC%E5%B2%9B';

SELECT hour(addtime),count(*) FROM qingchen_171.wqtab where game='%E7%AB%9E%E6%8A%80%E6%91%A9%E6%89%98' and addtime > '2013-06-30' and type = 'click' group by hour(addtime);

SELECT hour(addtime),count(*) FROM qingchen_171.wqtab where game='%C4%90ua Phi Thuy%E1%BB%81n 3D' and addtime > '2013-06-29' and addtime < '2013-06-30' and type = 'click' group by hour(addtime);

SELECT game,type,count(*),count(*)*0.3 amount FROM qingchen_171.wqtab where addtime > '2013-06-30' group by game,type;


SELECT game,type,count(*),count(*)*0.3 amount FROM qingchen_171.wqtab where addtime > '2013-06-30' group by game,type order by type,game;
