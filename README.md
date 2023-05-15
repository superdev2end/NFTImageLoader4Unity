# NFT Image Loader on Unity3D

## Screenshots

![Screenshot](https://github.com/superdev2end/NFTImageLoader4Unity/blob/main/Screenshot_1.png?raw=true)

![Screenshot](https://github.com/superdev2end/NFTImageLoader4Unity/blob/main/Screenshot_2.png?raw=true)

## Edit chain, network, contract's address and token's id
``` c#
    //The chain to interact with
    private string chain = "ethereum";
    //The network to interact with
    private string network = "goerli";
    //Contract to interact with
    private string contract = "0xd5b3d473c2379f471011e20edf2bd40c66158b97";
    //Token ID to pull from contract
    private string tokenId = "0";
```

## To display on RawImage UI Controller of Unity3D
``` c#
	GetComponent<RawImage>().texture = texture;
```

## To display on MeshRenderer 
``` c#
	GetComponent<MeshRenderer>().material.mainTexture = texture;
```

## Example - NFT metadata
``` json
{
  "name": "Pengolin NFT #0",
  "description": "Pengolin arts generated programatically",
  "external_url": "https://static.pengolincoin.xyz/arts/jsons/0",
  "image": "https://static.pengolincoin.xyz/arts/images/0",
  "index": 0,
  "attributes": [
    {
      "trait_type": "background",
      "value": "golf-yard"
    },
    {
      "trait_type": "tail",
      "value": "emerald-tail"
    },
    {
      "trait_type": "foot",
      "value": "golf"
    },
    {
      "trait_type": "pants",
      "value": "suit-p"
    },
    {
      "trait_type": "head",
      "value": "smile"
    },
    {
      "trait_type": "body",
      "value": "e-shirt"
    },
    {
      "trait_type": "cap",
      "value": "g-hat"
    },
    {
      "trait_type": "glasses",
      "value": "dark-g"
    },
    {
      "trait_type": "left tool",
      "value": "golfball"
    },
    {
      "trait_type": "right tool",
      "value": "golf-club"
    }
  ]
}
```

## Image url
```
	https://static.pengolincoin.xyz/arts/images/0
```

Email [superdev2end@gmail.com](mailto:superdev2end@gmail.com)
