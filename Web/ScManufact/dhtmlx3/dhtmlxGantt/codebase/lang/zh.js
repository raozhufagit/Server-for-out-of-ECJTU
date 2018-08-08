/**
 *  @desc: initialization of control errors
 *  @type: private
 *  @topic: 4
 */
GanttError.prototype._init = function()
{
    //connection errors
    this._errors[0] = "Connection error";
    this._errors[1] = "Cannot connect";
    this._errors[2] = "Server error";
    this._errors[3] = "Path is null or empty";
    this._errors[4] = "Filename is null or empty";
    this._errors[5] = "File (%0) is not found";

    //API errors
    this._errors[6] = "��ɱ��� ������ ����";
    this._errors[7] = "��ɱ��� ���� <= 100";
    this._errors[8] = "��ɱ��� ���� >= 0";
    this._errors[9] = "�� ���� ����(%0)�� ��ʱ";
    this._errors[10] = "�� ���� ����(%0)�� ��ʱ";
    this._errors[11] = "�� �ӳ� ����(%0)�� ��ʼʱ��";
    this._errors[12] = "�� ��ǰ ����(%0)�� ��ʼʱ��";
    this._errors[13] = "��Ŀ (%0) �Ѿ����";
    this._errors[14] = "��Ŀ (%0) ��ʼʱ�� < ������ʼʱ��";
    this._errors[15] = "���� (%0) ���ܳ�Ϊ ǰ������(%1) ��������";
    this._errors[16] = "ǰ������Ľ���ʱ��(%0) > ������(%1)�Ŀ�ʼʱ��";
    this._errors[17] = "��ǰ������(%0)������";
    this._errors[18] = "���� (%0) ��ʼʱ�� < ������ʼʱ��";
    this._errors[19] = "������ (%0) ����ʱ�� < ������(%1) ����ʱ��";
    this._errors[20] = "������ (%0) ��ʼʱ�� < ������(%1) ��ʼʱ��";
    this._errors[21] = "������ (%0) ������";
    this._errors[22] = "���� (%0) �Ѿ����";
    this._errors[23] = "��Ŀ (%0) �Ѿ����";
    this._errors[24] = "���� (%0) ��ʼʱ�� < ��Ŀ (%1) ��ʼʱ��";
    this._errors[25] = "������ (%0) ��ʼʱ�䲻��Ϊ��";
    this._errors[26] = "ǰ������ (%0) λ�ô���. ���ٸ�����ʱ ���� �ӳ�����(%1)�Ŀ�ʼʱ�� ";
    this._errors[27] = "ǰ������(%0) ������";
    this._errors[28] = "���Ӹ����� (%0) ��ʱ ���� ��ǰ ������ (%1)��ʼʱ�� ���� ����������(%1)��ʱ";
    this._errors[29] = "��ǰ������(%0)�Ŀ�ʼʱ�� ���� �ӳ������� (%1)�Ŀ�ʼʱ��";
    this._errors[30] = "����(%0) ������";
    this._errors[31] = "��Ŀ(%0) ������";
    this._errors[32] = "ǰ������(%0) �� ������(%1) ��������ͬһ��������";
    this._errors[33] = "��ǰ������(%0)�Ŀ�ʼʱ�� ���� �ӳ�������(%1)�Ŀ�ʼʱ��";
    this._errors[34] = "����(%0)�Ŀ�ʼʱ�� < ��Ŀ(%1)�Ŀ�ʼʱ��";
    this._errors[35] = "��ɱ��� ���� <= 100 and >= 0";
    this._errors[36] = "You may not connect a task to itself.";
    this._errors[37] = "Cannot parse this XML string.";
};


function LangName()
{
	//Task Lang Name
	this.tRename			= "������";
	this.tDelete			= "ɾ��";
	this.tStartDate			= "��ʼʱ��";
	this.tEndDate			= "����ʱ��"
	this.tDuration			= "��ʱ(Сʱ)";
	this.tPercent			= "��ɱ���%";
	this.tPredecessorTask	= "ǰ������";
	this.tSuccessorTask		= "��������";
	this.tChildTask			= "������";
	this.tPlanH				= "�ƻ���ʱ(Сʱ)";
	this.tAlarm				= "����(��)";
	this.tParentTask		= "������";
	this.tMoveChildTask		= "�ƶ�������";
	this.tManager			= "�������";
	
	//Project Lang Name
	this.pStartDate	= "��ʼʱ��";
	this.pEndDate	= "����ʱ��"
	this.pDuration	= "��ʱ(Сʱ)";
	this.pRename	= "��������Ŀ";
	this.pNewPro	= "������Ŀ";
	this.pDelete	= "ɾ����Ŀ";
	this.pPercent	= "��ɱ���%";
	this.pTask		= "���������";
	this.pPlanH		= "�ƻ���ʱ(Сʱ)";
	this.pManager	= "��Ŀ����";
	//public
	this.name			= "����";
	this.newName		= "������";
	this.buttonOk		= "ȷ��";
	this.buttonCancel	= "ȡ��";
	this.labSet			= "����";
	this.labAdd			= "����";
	this.buttonSave		= "����";
	this.buttonSync		= "���¼���";
	
}