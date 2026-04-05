# RunAndGunSurvivar

## はじめに

- このゲームはUnityを使用した3Dゲームの製作を学習ために作成されています。
- タイトル画面から１つのステージを遊べるように作りました。

## 作品の概要

- ３Ｄアクションです。
- 近接、遠距離攻撃を駆使して敵を倒し、ゴールにたどり着くとゲームクリア。

### デモプレイ


#### 操作方法
- 移動・・・「←」キー、「→」キー
- ジャンプ・・・Spaceキー
- 近距離攻撃・・・「C」キー
- 遠距離攻撃・・・Enterキー


#### 画面説明

| 参考画像 | 名称 | 説明 |
| :-------: | :--------: | :------------------------------------------------------------------------------------------------- |
|| 機体 | 操作するロボットです。ゴールにたどり着くことが目的です。 |
|| 近距離攻撃 | 射程の短い全方位攻撃です。遠距離攻撃に比べて威力が高い。 |
|| 遠距離攻撃 | 射程無限のエネルギー弾を放ちます。弾数とリロード回数に制限があるため、考えて使いましょう |
|  | トラップ | 当たると痛い、トゲ付きの罠です。 |
|  | エネミー | 敵です。邪魔になるので容赦なく攻撃しましょう。 |
|  | 体力回復アイテム | 機体が触れるとＨＰが回復します。 |
|  | マガジン回復アイテム | 機体が触れるとマガジンの残数を回復します。 |
|  | 火力アップアイテム | 遠距離攻撃の威力をアップします。最大３回。 |
|  | ゴール | 最終地点、たどり着くとゲームクリアです。|
|  | ＨＰ | 機体の耐久値です。敵かトラップに当たると減少します。３回当たるとゲームオーバーです。 |
|  | 弾数 | 遠距離攻撃の残り弾数です。０になるとマガジンを消費してリロードします。 |
|  | マガジン | 弾数を補充できるマガジンです。リロードすると減少します。アイテムで回復。 |
|  | 火力 | 遠距離攻撃の攻撃力です。最大３段階上昇します。 |
|  | スコア | 敵を倒すことで得られるスコアです。正味フレーバー |

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
