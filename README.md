# RunAndGunSurvivar

## はじめに

- このゲームはUnityを使用した3Dゲームの製作を学習ために作成されています。
- タイトル画面から１つのステージを遊べるように作りました。

## 作品の概要

- ３Ｄアクションです。
- 近接、遠距離攻撃を駆使して敵を倒し、ゴールにたどり着くとゲームクリア。

### デモプレイ

<video src="https://github.com/user-attachments/assets/fadf5747-1e0c-4e71-8182-2fc447e48478" controles=true></video>



#### 操作方法
- 移動・・・「←」キー、「→」キー
- ジャンプ・・・Spaceキー
- 近距離攻撃・・・「C」キー
- 遠距離攻撃・・・Enterキー


#### 画面説明

| 参考画像 | 名称 | 説明 |
| :-------: | :--------: | :------------------------------------------------------------------------------------------------- |
| <img width="250" height="344" alt="image" src="https://github.com/user-attachments/assets/adc0e0e1-3690-4a64-a5b5-1bed51bb979a" /> | 機体 | 操作するロボットです。ゴールにたどり着くことが目的です。 |
| <img width="683" height="309" alt="image" src="https://github.com/user-attachments/assets/83defe1c-2318-4439-bf3d-93a81ed8595d" /> | 近距離攻撃 | 射程の短い全方位攻撃です。遠距離攻撃に比べて威力が高い。 |
| <img width="248" height="380" alt="image" src="https://github.com/user-attachments/assets/ad7845a1-74b1-44b5-a5bd-afb4c9a1e21a" /> | 遠距離攻撃 | 射程無限のエネルギー弾を放ちます。弾数とリロード回数に制限があるため、考えて使いましょう |
| <img width="866" height="233" alt="image" src="https://github.com/user-attachments/assets/51195661-2580-4ea8-895b-ee7f4baa8240" /> | トラップ | 当たると痛い、トゲ付きの罠です。 |
| <img width="235" height="204" alt="image" src="https://github.com/user-attachments/assets/39877271-16ad-4a2f-bcc9-9e1cf7daadfb" /> | エネミー | 敵です。邪魔になるので容赦なく攻撃しましょう。 |
| <img width="139" height="111" alt="image" src="https://github.com/user-attachments/assets/ff664c22-3d03-4cb4-bc41-5a0c30dc3f8a" /> | 体力回復アイテム | 機体が触れるとＨＰが回復します。 |
| <img width="182" height="135" alt="image" src="https://github.com/user-attachments/assets/a89ee2c1-8865-48bc-9557-56069e1fa933" /> | マガジン回復アイテム | 機体が触れるとマガジンの残数を回復します。 |
| <img width="156" height="138" alt="image" src="https://github.com/user-attachments/assets/736b9dc7-2e57-4f67-93a8-77bb4298ad25" /> | 火力アップアイテム | 遠距離攻撃の威力をアップします。最大３回。 |
| <img width="308" height="119" alt="image" src="https://github.com/user-attachments/assets/3babec49-6a36-4a95-84d3-ada9ff7afdaf" /> | ゴール | 最終地点、たどり着くとゲームクリアです。|
| <img width="256" height="90" alt="image" src="https://github.com/user-attachments/assets/65b21416-5410-448f-9740-8d2d7220a333" /> | ＨＰ | 機体の耐久値です。敵かトラップに当たると減少します。３回当たるとゲームオーバーです。 |
| <img width="208" height="98" alt="image" src="https://github.com/user-attachments/assets/066b10a1-1507-4468-9677-70a916090fc4" /> | 弾数 | 遠距離攻撃の残り弾数です。０になるとマガジンを消費してリロードします。 |
| <img width="213" height="93" alt="image" src="https://github.com/user-attachments/assets/c8d8b05c-b774-4279-b1b4-da710f6c25e4" /> | マガジン | 弾数を補充できるマガジンです。リロードすると減少します。アイテムで回復。 |
| <img width="303" height="105" alt="image" src="https://github.com/user-attachments/assets/c7fd59cc-7db3-499c-853c-5b5046991441" /> | 火力 | 遠距離攻撃の攻撃力です。最大３段階上昇します。 |
| <img width="327" height="89" alt="image" src="https://github.com/user-attachments/assets/fb418cea-8c67-433d-a531-a217f769e7e7" /> | スコア | 敵を倒すことで得られるスコアです。正味フレーバー |

## プログラムの場所    
- Assets/Scripts・・・各スクリプト　

## ツールなど    
- 使用言語:C#
- 開発ツール:  Unity Editor 6000.3.5f2
              Microsoft Visual Studio Community 2026（18.3.1）
- バージョン管理: SourceTree Virsion 3.4.27


## 参考書籍・使用アセット    
- 参考書籍　Unity2021 3D/2Dゲーム開発実践入門（吉谷 幹人 様著）
  　ＵＲＬ：https://www.socym.co.jp/book/1315

  
- 使用アセット
  - 　Slash Effects FREE（https://assetstore.unity.com/packages/vfx/particles/spells/slash-effects-free-295209）
  -   Brick Toy 3D Low Poly Fighter Robots（https://assetstore.unity.com/packages/3d/props/brick-toy-3d-low-poly-fighter-robots-304279）
  -   Low Poly Street Pack（https://assetstore.unity.com/packages/3d/environments/urban/low-poly-street-pack-67475）
  -   Free Quick Effects Vol. 1（https://assetstore.unity.com/packages/vfx/particles/free-quick-effects-vol-1-304424）
  -   Russian buildings lowpoly pack（https://assetstore.unity.com/packages/3d/environments/urban/russian-buildings-lowpoly-pack-80518）
  -   Fantasy Skybox FREE（https://assetstore.unity.com/packages/2d/textures-materials/sky/fantasy-skybox-free-18353）
    
- 参考サイト　https://creator.cluster.mu/2023/04/19/explosion_particle/
  　

## 製作期間
- ２週間程度

## 制作のポイント
- ３Ｄゲームを学ぶにあたり、モデル・モーションや当たり判定を確認しながら制作しました。
- プレイに幅を持たせるため、攻撃パターンを２種類実装しました。

## 課題
- ステージ数が１つしかないこと
- エネミーからの攻撃など、敵からのアクションがない
- どのエネミーも同じスコアになっており、ゲーム性がない


## おわりに
- ＵＩやグラフィックス、スクリプトでの扱い方など、２Ｄと異なる部分が多く、学ぶことが多かったです。
- 今回はWebGL形式で出力になるのですが、開始時のロードが長かったりなど、ゲーム体験として改善しなければいけないと感じる部分も多くあります。
- （もしプレイしていただけるのならこちらから　⇒　https://www.na1117-lic.net/game/RunAndGunSurvivar/）
