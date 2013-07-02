SELECT * FROM qingchen_171.wqtab order by idwqtab desc limit 0,40;

SELECT * FROM qingchen_171.wqtab where type='click' order by idwqtab desc limit 0,40;

'2013-06-29 16:44:12'

SELECT * FROM qingchen_171.wqtab where addtime > '2013-06-29' and type = 'click' and game = '%E4%BF%9D%E5%8D%AB%E9%92%93%E9%B1%BC%E5%B2%9B';

SELECT hour(addtime),count(*) FROM qingchen_171.wqtab where game='%E4%BF%9D%E5%8D%AB%E9%92%93%E9%B1%BC%E5%B2%9B' and addtime > '2013-06-30' and type = 'view' group by hour(addtime);

SELECT hour(addtime),count(*) FROM qingchen_171.wqtab where game='%E4%BF%9D%E5%8D%AB%E9%92%93%E9%B1%BC%E5%B2%9B' and date_format(addtime,'%Y-%m-%d') = '2013-07-02' and type = 'click' group by hour(addtime);

SELECT game,type,count(*),count(*)*0.3 amount FROM qingchen_171.wqtab where date_format(addtime,'%Y-%m-%d') = '2013-06-30' group by game,type;

select v.game,v.cnt,c.cnt,c.amount from
(select game,count(*) cnt from wqtab where type = 'view' and date_format(addtime,'%Y-%m-%d') = '2013-07-02' group by game) v,
(select game,count(*) cnt,count(*)*0.3 amount from wqtab where type = 'click' and date_format(addtime,'%Y-%m-%d') = '2013-07-02' group by game) c,
wqgames g
where v.game = c.game and c.game = g.name and g.chnname = '太空竞速';



SELECT game,type,count(*),count(*)*0.3 amount FROM qingchen_171.wqtab where addtime > '2013-07-01' group by game,type order by type,game;
