using System.Collections;
using System.Numerics;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ERC1155BalanceOfExample : MonoBehaviour
{
    public Text loginCheck;
    async void Start()
    {
        string chain = "ethereum";
        string network = "rinkeby";
        string contract = "0x88B48F654c30e99bc2e4A1559b4Dcf1aD93FA656";
        string account = PlayerPrefs.GetString("Account");
        string tokenId = "58677601423738304715409830025028677902728782946448163363061093825787207876609";

        BigInteger balanceOf = await ERC1155.BalanceOf(chain, network, contract, account, tokenId);
        print(balanceOf);

        if (balanceOf > 0)
        {
            loginCheck.text = account;
        }
    }
}
