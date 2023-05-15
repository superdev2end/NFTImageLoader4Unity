using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

//Used by metadata class for storing attributes
public class Attributes
{
    //The type or name of a given trait
    public string trait_type;
    //The value associated with the trait_type
    public string value;
}

//Used for storing NFT metadata from standard NFT json files
public class Metadata
{
    //List storing attributes of the NFT
    public List<Attributes> attributes { get; set; }
    //Description of the NFT
    public string description { get; set; }
    //An external_url related to the NFT (often a website)
    public string external_url { get; set; }
    //image stores the NFTs URI for image NFTs
    public string image { get; set; }
    //Name of the NFT
    public string name { get; set; }
}

//Interacting with blockchain
public class NftImageLoader : MonoBehaviour
{
    //The chain to interact with
    private string chain = "ethereum";
    //The network to interact with
    private string network = "goerli";
    //Contract to interact with
    private string contract = "0xd5b3d473c2379f471011e20edf2bd40c66158b97";
    //Token ID to pull from contract
    private string tokenId = "0";
    //Used for storing metadata
    Metadata metadata;

    private void Start()
    {
        //Starts async function to get the NFT image
        GetNFTImage();
    }

    async private void GetNFTImage()
    {
        //Interacts with the Blockchain to find the URI related to that specific token
        string URI = await ERC721.URI(chain, network, contract, tokenId);

        //Perform webrequest to get JSON file from URI
        using (UnityWebRequest webRequest = UnityWebRequest.Get(URI))
        {
            //Sends webrequest
            await webRequest.SendWebRequest();
            //Gets text from webrequest
            string metadataString = webRequest.downloadHandler.text;
            //Converts the metadata string to the Metadata object
            metadata = JsonConvert.DeserializeObject<Metadata>(metadataString);
        }

        //Performs another web request to collect the image related to the NFT
        using (UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(metadata.image))
        {
            //Sends webrequest
            await webRequest.SendWebRequest();

            //Gets the image from the web request and stores it as a texture
            Texture texture = DownloadHandlerTexture.GetContent(webRequest);

            //Sets the objects main render material to the texture
            GetComponent<RawImage>().texture = texture;
        }
    }
}