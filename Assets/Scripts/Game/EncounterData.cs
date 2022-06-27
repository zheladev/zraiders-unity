

public struct EncounterData {
    public int enemyNumber {
            get {
                return enemyNumber;
            }
            set {
                enemyNumber = value;
            }
    }
    public int raiderNumber {
        get {
            return raiderNumber;
        }
        set {
            raiderNumber = value;
        }
    }

    public string stage {
        get {
            return stage;
        }
        set {
            stage = value;
        }
    }

    public EncounterData(int en, int rn, string s) => (enemyNumber, raiderNumber, stage) = (en, rn, s);

    public override string ToString() => $"{enemyNumber}, {raiderNumber}, {stage}";

}
