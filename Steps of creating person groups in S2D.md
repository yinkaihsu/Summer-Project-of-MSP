Steps of creating person groups in S2D
===

## Step 1

*    [Create a Person Group](https://eastasia.dev.cognitive.microsoft.com/docs/services/563879b61984550e40cbbe8d/operations/563879b61984550f30395244)
*    Click **East Asia**
*    Type 'winner' and 'loser' in **personGroupId** separately
*    Type our FaceAPI key in **Ocp-Apim-Subscription-Key**
*    **Name** the Person Group in your JSON file
*    **Send** it

## Step 2

*    [List Person Groups](https://eastasia.dev.cognitive.microsoft.com/docs/services/563879b61984550e40cbbe8d/operations/563879b61984550f30395248)
*    Click **East Asia**
*    Type our FaceAPI key in **Ocp-Apim-Subscription-Key**
*    **Send** it
*    Get the **personGroupId**

Our info of groups:
```
[{
  "personGroupId": "loser",
  "name": "loser",
  "userData": null
}, {
  "personGroupId": "winner",
  "name": "winner",
  "userData": null
}]
```

## Step 3

*    [Create a Person](https://eastasia.dev.cognitive.microsoft.com/docs/services/563879b61984550e40cbbe8d/operations/563879b61984550f3039523c)
*    Click **East Asia**
*    Type 'winner' and 'loser' in **personGroupId** separately
*    **Name** the Person in your JSON file
*    Type our FaceAPI key in **Ocp-Apim-Subscription-Key**
*    **Send** it

## Step 4

*    [List Persons in a Person Group](https://eastasia.dev.cognitive.microsoft.com/docs/services/563879b61984550e40cbbe8d/operations/563879b61984550f30395241)
*    Click **East Asia**
*    Type 'winner' and 'loser' in **personGroupId** separately
*    Type our FaceAPI key in **Ocp-Apim-Subscription-Key**
*    **Send** it
*    Get the **personId**

Our info of group winner:
```
[{
  "personId": "2ae5cb06-e58c-46d5-8f29-6cf1afd0dd81",
  "persistedFaceIds": [],
  "name": "winner",
  "userData": null
}]
```
Our info of group loser:
```
[{
  "personId": "8955d99f-7fd5-414a-acef-805b9971a4a6",
  "persistedFaceIds": [],
  "name": "loser",
  "userData": null
}]
```

## Step 5

*    [Add a Person Face](https://eastasia.dev.cognitive.microsoft.com/docs/services/563879b61984550e40cbbe8d/operations/563879b61984550f3039523b)
*    Click **East Asia**
*    Type 'winner' in **personGroupId** with **personId** and 'loser' in **personGroupId** with **personId** separately
*    Type our FaceAPI key in **Ocp-Apim-Subscription-Key**
*    Add **url** of images that are winners or losers in your JSON file
        *    Reference to **圖片-單身透視鏡**

## Step 6

*    [Train Person Group](https://eastasia.dev.cognitive.microsoft.com/docs/services/563879b61984550e40cbbe8d/operations/563879b61984550f30395249)
*    Click **East Asia**
*    Type 'winner' and 'loser' in **personGroupId** separately
*    Type our FaceAPI key in **Ocp-Apim-Subscription-Key**
*    **Send** it

## Step 7 - Final Check

*    [List Persons in a Person Group](https://eastasia.dev.cognitive.microsoft.com/docs/services/563879b61984550e40cbbe8d/operations/563879b61984550f30395241)
*    Click **East Asia**
*    Type 'winner' and 'loser' in **personGroupId** separately
*    Type our FaceAPI key in **Ocp-Apim-Subscription-Key**
*    **Send** it
*    Check the number of **persistedFaceIds** is the same as the number of images you uploaded

Our info of group winner:
```
[{
  "personId": "2ae5cb06-e58c-46d5-8f29-6cf1afd0dd81",
  "persistedFaceIds": ["27b058a5-54a9-4ce7-a13c-30dd7572d0f2", "89739b33-344a-47a1-a4ab-b2b8e3a660be", "8dcdc147-7901-4fbb-a25c-8a5e1e6cbe81", "94513759-d0a6-491d-8315-c5facb40198e", "afa23e65-9762-44e6-aa8f-af8981817177", "b28bbf34-dd71-41df-b68a-9be8bae84bb3", "cb065eb1-3e40-4171-a7e6-c0fc5787e24a", "daa373e6-52cd-42ef-b8fa-b24d5b4ca4fd", "f1d20d55-e750-46b5-b4d6-d9471da08906", "fcf14872-3ed3-4a3c-a100-b66800dd7c11"],
  "name": "winner",
  "userData": null
}]
```
Our info of group loser:
```
[{
  "personId": "8955d99f-7fd5-414a-acef-805b9971a4a6",
  "persistedFaceIds": ["0228bdb6-48aa-456e-88d4-95410f7e2c57", "17fb2713-82a1-43cc-bf2e-36660d782765", "4896d21c-b3bb-4b77-bd47-fb0f6d32efb3", "5ac2a5cb-6627-4835-8f1d-501c70019086", "73d25cad-8903-4494-97a6-c113eefeb112", "7aae1661-4913-4d9a-8a4c-c73519f5af97", "b0cf64a4-18ee-4f90-b565-5fe820a56a7f", "cdeb8b56-5ef6-4e0d-8371-64aa4770ff83", "cf7edf11-cf4f-4256-aefe-52afcefbba97", "df77e097-2d21-4bd4-a28f-3c8f47d5392e"],
  "name": "loser",
  "userData": null
}]
```

## Finish

---