using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ilan.Google.API.ImageSearch;
using System.Text.RegularExpressions;

public class AssignImage : MonoBehaviour
{
    public string strNonFormattedQuery;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    string FormatQuery(string nonFormatted)
    {
        string strFormattedQuery = Regex.Replace(nonFormatted, @"\s{1,}", "+");

        return strFormattedQuery;
    }
}
