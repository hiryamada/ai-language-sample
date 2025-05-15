# Azure AI Vision サンプル（AI-102 ラボ5）

- ラボ5を起動（以下の手順はラボ内で実施）
- Azure portalで「Azure AI Language」リソースを作成
  - リソースグループは作成済みのものを使用
- 環境変数「LANGUAGE_ENDPOINT」を作成。値: リソースのエンドポイント
- 環境変数「LANGUAGE_KEY」を作成。値: リソースのキー
- Visual Studio Codeを起動（以下の手順はVisual Studio Code内で実施）
- 本リポジトリをクローン
- ターミナルを起動し、dotnet run でプログラムを実行

## 使用しているライブラリ

https://www.nuget.org/packages/Azure.AI.TextAnalytics

## 参考

https://learn.microsoft.com/ja-jp/azure/ai-services/language-service/language-detection/quickstart?tabs=windows&pivots=programming-language-csharp