using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

public enum BloodType
{
    APlus,
    AMinus,
    BPlus,
    BMinus,
    ABPlus,
    ABMinus,
    OPlus,
    OMinus
};

public class SecondMinigameMaanger : MonoBehaviour
{
    [SerializeField] private GameObject GameController;
    private GameController gameController;
    
    // GameObject Placeholders
    [SerializeField] private GameObject bloodBagTarget;
    [FormerlySerializedAs("fileTargetfirst")] [SerializeField] private GameObject fileTargetFirst;
    private PacientFile PacientFileComponentFirst;
    [SerializeField] private GameObject fileTargetSecond;
    private PacientFile PacientFileComponentSecond;
    [SerializeField] private GameObject fileTargetThird;
    private PacientFile PacientFileComponentThird;
    
    // Blood Bags and Pacient Files Prefabs
    [SerializeField] private GameObject bloodBagPrefabAPlus;
    [SerializeField] private GameObject bloodBagPrefabAMinus;
    [SerializeField] private GameObject bloodBagPrefabBPlus;
    [SerializeField] private GameObject bloodBagPrefabBMinus;
    [SerializeField] private GameObject bloodBagPrefabABPlus;
    [SerializeField] private GameObject bloodBagPrefabABMinus;
    [SerializeField] private GameObject bloodBagPrefabOPlus;
    [SerializeField] private GameObject bloodBagPrefabOMinus;
    
    [SerializeField] private GameObject pacientFilePrefabAPlus;
    [SerializeField] private GameObject pacientFilePrefabAMinus;
    [SerializeField] private GameObject pacientFilePrefabBPlus;
    [SerializeField] private GameObject pacientFilePrefabBMinus;
    [SerializeField] private GameObject pacientFilePrefabABPlus;
    [SerializeField] private GameObject pacientFilePrefabABMinus;
    [SerializeField] private GameObject pacientFilePrefabOPlus;
    [SerializeField] private GameObject pacientFilePrefabOMinus;
    
    //Bag and File types
    private BloodType _bagType;
    private BloodType _firstFileType;
    private BloodType _secondFileType;
    private BloodType _thirdFileType;
    private BloodType _rightFile;
    
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameController.GetComponent<GameController>();
        
        PacientFileComponentFirst = fileTargetFirst.GetComponent<PacientFile>();
        PacientFileComponentSecond = fileTargetSecond.GetComponent<PacientFile>();
        PacientFileComponentThird = fileTargetThird.GetComponent<PacientFile>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartMinigame()
    {
        Random random = new Random();
        Array allBloodTypes = Enum.GetValues(typeof(BloodType));
        _bagType = (BloodType)allBloodTypes.GetValue(random.Next(allBloodTypes.Length));
        
        //Get Rigth File (Conditioned Random)

        BloodType[] possibleValues = GetPossibleBloodTypes(_bagType);
        
        _rightFile = (BloodType)possibleValues.GetValue(random.Next(possibleValues.Length));
        
        BloodType[] otherBloodTypes = RemoveFromArray((BloodType[])allBloodTypes, possibleValues);
        _secondFileType = (BloodType)otherBloodTypes.GetValue(random.Next(otherBloodTypes.Length));
        
        BloodType[] otherOtherBloodTypes = RemoveFromArray(otherBloodTypes, new []{_secondFileType});
        _thirdFileType = (BloodType)otherOtherBloodTypes.GetValue(random.Next(otherOtherBloodTypes.Length));
        
        DistribuitBloodTypes(_rightFile, _secondFileType, _thirdFileType); 
        
        PacientFileComponentFirst.SetType(_firstFileType);
        PacientFileComponentSecond.SetType(_secondFileType);
        PacientFileComponentThird.SetType(_thirdFileType);
            
    }

    BloodType[] RemoveFromArray(BloodType[] array, BloodType[] values)
    {
        List<BloodType> finalArray = new System.Collections.Generic.List<BloodType>();
        foreach (var o in array)
        {
            var keep = true;
            foreach (var value in values)
            {
                if (o == value)
                {
                    keep = false;
                }
            }
            if (keep) finalArray.Add(o);
        }
        return finalArray.ToArray();
    }
    
    BloodType[] GetPossibleBloodTypes(BloodType _bagType)
    {
        switch (_bagType)
        {
            case BloodType.APlus: 
                return new[] {BloodType.APlus, BloodType.ABPlus};
            case BloodType.AMinus:
                return new[] {BloodType.APlus, BloodType.AMinus, BloodType.ABPlus, BloodType.ABMinus};
            case BloodType.BPlus:
                return new[] { BloodType.BPlus, BloodType.ABPlus };
            case BloodType.BMinus:
                return new[] { BloodType.BPlus, BloodType.BMinus, BloodType.ABPlus, BloodType.ABMinus };
            case BloodType.ABPlus:
                return new[] { BloodType.ABPlus};
            case BloodType.ABMinus:
                return new[] {BloodType.ABPlus, BloodType.ABMinus};
            case BloodType.OPlus:
                return new[] {BloodType.APlus, BloodType.BPlus, BloodType.ABPlus, BloodType.OPlus};
            case BloodType.OMinus:
                return new[] {BloodType.APlus, BloodType.AMinus, BloodType.BPlus, BloodType.BMinus, BloodType.ABPlus, BloodType.ABMinus, BloodType.OPlus, BloodType.OMinus};
            default:
                return new BloodType[] { };
        }
    }

    void DistribuitBloodTypes(BloodType rigthFile, BloodType secondFile, BloodType thirdFile)
    {
        var random = new Random();
        BloodType[] fileOrder = { rigthFile, secondFile, thirdFile };

        for (var i = 0; i < 2; i++)
        {
            var file = random.Next(0, 2);
            BloodType temp;
            temp = fileOrder[i];
            fileOrder[i] =  fileOrder[file];
            fileOrder[file] = temp;
        }

        _firstFileType = fileOrder[0];
        _secondFileType = fileOrder[1];
        _thirdFileType = fileOrder[2];
    }
    
    public BloodType GetRightFile()
    {
        return _rightFile;
    }

    public void End(bool win)
    {
        gameController.endMinigame2(win);
    }
}
