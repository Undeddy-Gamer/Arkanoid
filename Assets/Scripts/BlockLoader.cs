using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO; // for File Input and Output
using System.Data;
using ExcelDataReader; //For reading excel files

public class BlockLoader : MonoBehaviour
{

    public string fileName = "Data/Excel/Blocks.xlsx";
    public string sheetName = "Level1";
    public Vector2 spacing = new Vector2(2, 2);
    public GameObject blockPrefab;
    public Sprite[] blockSprites;


    void Start()
    {
        IExcelDataReader excelReader = OpenExcelFile(fileName);
        GenerateBlocksFromExcel(excelReader, sheetName);
    }


    public IExcelDataReader OpenExcelFile(string fileName)
    {
        string fullPath = Application.dataPath + "/" + fileName;

        FileStream stream = File.Open(fullPath, FileMode.Open, FileAccess.Read);

        return ExcelReaderFactory.CreateOpenXmlReader(stream);

       
    }

    public void GenerateBlocksFromExcel(IExcelDataReader excelReader, string sheetName)
    {
        // Convert Excel ExcelReader to Dataset
        DataSet result = excelReader.AsDataSet();
        DataTable table = result.Tables[sheetName];
        // Loop through all Rows
        
        for ( int y = 0; y < table.Rows.Count; y++)
        {
            //get columns on at y index
            DataRow row = table.Rows[y];
            for ( int x = 0; x < row.ItemArray.Length; x++)
            {
                //if (!row.ItemArray[x].Equals(null))
                string value = row.ItemArray.GetValue(x).ToString();
                if (value != "")
                {
                    string blockType = value;
                    // Create Block with Type & Position
                    CreateBlock(blockType, new Vector2(x * spacing.x, (y * spacing.y) * -1));
                }


            }
        }


    }

    public void CreateBlock(string blockType, Vector2 position)
    {
        GameObject clone = Instantiate(blockPrefab, transform);
        clone.transform.localPosition = position;
        SpriteRenderer rend = clone.GetComponent<SpriteRenderer>();
        Block blockScript = clone.GetComponent<Block>();

        switch (blockType)
        {
            case "R":
                rend.sprite = blockSprites[0];                
                blockScript.PointValue = 10;
                break;
            case "B":
                rend.sprite = blockSprites[1];
                blockScript.PointValue = 5;
                break;
            case "Y":
                rend.sprite = blockSprites[2];
                blockScript.PointValue = 3;
                break;
            case "G":
                rend.sprite = blockSprites[3];
                blockScript.PointValue = 2;
                break;
            case "P":
                rend.sprite = blockSprites[4];
                blockScript.PointValue = 1;
                break;
            default:
                break;
        }
    }

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
