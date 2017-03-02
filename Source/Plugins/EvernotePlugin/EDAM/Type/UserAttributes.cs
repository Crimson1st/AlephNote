/**
 * Autogenerated by Thrift
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 */

using System;
using System.Collections.Generic;
using System.Text;
using AlephNote.Plugins.Evernote.Thrift.Protocol;

namespace AlephNote.Plugins.Evernote.EDAM.Type
{

  #if !SILVERLIGHT && !NETFX_CORE
  [Serializable]
  #endif
  public partial class UserAttributes : TBase
  {
    private string _defaultLocationName;
    private double _defaultLatitude;
    private double _defaultLongitude;
    private bool _preactivation;
    private List<string> _viewedPromotions;
    private string _incomingEmailAddress;
    private List<string> _recentMailedAddresses;
    private string _comments;
    private long _dateAgreedToTermsOfService;
    private int _maxReferrals;
    private int _referralCount;
    private string _refererCode;
    private long _sentEmailDate;
    private int _sentEmailCount;
    private int _dailyEmailLimit;
    private long _emailOptOutDate;
    private long _partnerEmailOptInDate;
    private string _preferredLanguage;
    private string _preferredCountry;
    private bool _clipFullPage;
    private string _twitterUserName;
    private string _twitterId;
    private string _groupName;
    private string _recognitionLanguage;
    private string _referralProof;
    private bool _educationalDiscount;
    private string _businessAddress;
    private bool _hideSponsorBilling;
    private bool _taxExempt;
    private bool _useEmailAutoFiling;
    private ReminderEmailConfig _reminderEmailConfig;

    public string DefaultLocationName
    {
      get
      {
        return _defaultLocationName;
      }
      set
      {
        __isset.defaultLocationName = true;
        this._defaultLocationName = value;
      }
    }

    public double DefaultLatitude
    {
      get
      {
        return _defaultLatitude;
      }
      set
      {
        __isset.defaultLatitude = true;
        this._defaultLatitude = value;
      }
    }

    public double DefaultLongitude
    {
      get
      {
        return _defaultLongitude;
      }
      set
      {
        __isset.defaultLongitude = true;
        this._defaultLongitude = value;
      }
    }

    public bool Preactivation
    {
      get
      {
        return _preactivation;
      }
      set
      {
        __isset.preactivation = true;
        this._preactivation = value;
      }
    }

    public List<string> ViewedPromotions
    {
      get
      {
        return _viewedPromotions;
      }
      set
      {
        __isset.viewedPromotions = true;
        this._viewedPromotions = value;
      }
    }

    public string IncomingEmailAddress
    {
      get
      {
        return _incomingEmailAddress;
      }
      set
      {
        __isset.incomingEmailAddress = true;
        this._incomingEmailAddress = value;
      }
    }

    public List<string> RecentMailedAddresses
    {
      get
      {
        return _recentMailedAddresses;
      }
      set
      {
        __isset.recentMailedAddresses = true;
        this._recentMailedAddresses = value;
      }
    }

    public string Comments
    {
      get
      {
        return _comments;
      }
      set
      {
        __isset.comments = true;
        this._comments = value;
      }
    }

    public long DateAgreedToTermsOfService
    {
      get
      {
        return _dateAgreedToTermsOfService;
      }
      set
      {
        __isset.dateAgreedToTermsOfService = true;
        this._dateAgreedToTermsOfService = value;
      }
    }

    public int MaxReferrals
    {
      get
      {
        return _maxReferrals;
      }
      set
      {
        __isset.maxReferrals = true;
        this._maxReferrals = value;
      }
    }

    public int ReferralCount
    {
      get
      {
        return _referralCount;
      }
      set
      {
        __isset.referralCount = true;
        this._referralCount = value;
      }
    }

    public string RefererCode
    {
      get
      {
        return _refererCode;
      }
      set
      {
        __isset.refererCode = true;
        this._refererCode = value;
      }
    }

    public long SentEmailDate
    {
      get
      {
        return _sentEmailDate;
      }
      set
      {
        __isset.sentEmailDate = true;
        this._sentEmailDate = value;
      }
    }

    public int SentEmailCount
    {
      get
      {
        return _sentEmailCount;
      }
      set
      {
        __isset.sentEmailCount = true;
        this._sentEmailCount = value;
      }
    }

    public int DailyEmailLimit
    {
      get
      {
        return _dailyEmailLimit;
      }
      set
      {
        __isset.dailyEmailLimit = true;
        this._dailyEmailLimit = value;
      }
    }

    public long EmailOptOutDate
    {
      get
      {
        return _emailOptOutDate;
      }
      set
      {
        __isset.emailOptOutDate = true;
        this._emailOptOutDate = value;
      }
    }

    public long PartnerEmailOptInDate
    {
      get
      {
        return _partnerEmailOptInDate;
      }
      set
      {
        __isset.partnerEmailOptInDate = true;
        this._partnerEmailOptInDate = value;
      }
    }

    public string PreferredLanguage
    {
      get
      {
        return _preferredLanguage;
      }
      set
      {
        __isset.preferredLanguage = true;
        this._preferredLanguage = value;
      }
    }

    public string PreferredCountry
    {
      get
      {
        return _preferredCountry;
      }
      set
      {
        __isset.preferredCountry = true;
        this._preferredCountry = value;
      }
    }

    public bool ClipFullPage
    {
      get
      {
        return _clipFullPage;
      }
      set
      {
        __isset.clipFullPage = true;
        this._clipFullPage = value;
      }
    }

    public string TwitterUserName
    {
      get
      {
        return _twitterUserName;
      }
      set
      {
        __isset.twitterUserName = true;
        this._twitterUserName = value;
      }
    }

    public string TwitterId
    {
      get
      {
        return _twitterId;
      }
      set
      {
        __isset.twitterId = true;
        this._twitterId = value;
      }
    }

    public string GroupName
    {
      get
      {
        return _groupName;
      }
      set
      {
        __isset.groupName = true;
        this._groupName = value;
      }
    }

    public string RecognitionLanguage
    {
      get
      {
        return _recognitionLanguage;
      }
      set
      {
        __isset.recognitionLanguage = true;
        this._recognitionLanguage = value;
      }
    }

    public string ReferralProof
    {
      get
      {
        return _referralProof;
      }
      set
      {
        __isset.referralProof = true;
        this._referralProof = value;
      }
    }

    public bool EducationalDiscount
    {
      get
      {
        return _educationalDiscount;
      }
      set
      {
        __isset.educationalDiscount = true;
        this._educationalDiscount = value;
      }
    }

    public string BusinessAddress
    {
      get
      {
        return _businessAddress;
      }
      set
      {
        __isset.businessAddress = true;
        this._businessAddress = value;
      }
    }

    public bool HideSponsorBilling
    {
      get
      {
        return _hideSponsorBilling;
      }
      set
      {
        __isset.hideSponsorBilling = true;
        this._hideSponsorBilling = value;
      }
    }

    public bool TaxExempt
    {
      get
      {
        return _taxExempt;
      }
      set
      {
        __isset.taxExempt = true;
        this._taxExempt = value;
      }
    }

    public bool UseEmailAutoFiling
    {
      get
      {
        return _useEmailAutoFiling;
      }
      set
      {
        __isset.useEmailAutoFiling = true;
        this._useEmailAutoFiling = value;
      }
    }

    public ReminderEmailConfig ReminderEmailConfig
    {
      get
      {
        return _reminderEmailConfig;
      }
      set
      {
        __isset.reminderEmailConfig = true;
        this._reminderEmailConfig = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT && !NETFX_CORE
    [Serializable]
    #endif
    public struct Isset {
      public bool defaultLocationName;
      public bool defaultLatitude;
      public bool defaultLongitude;
      public bool preactivation;
      public bool viewedPromotions;
      public bool incomingEmailAddress;
      public bool recentMailedAddresses;
      public bool comments;
      public bool dateAgreedToTermsOfService;
      public bool maxReferrals;
      public bool referralCount;
      public bool refererCode;
      public bool sentEmailDate;
      public bool sentEmailCount;
      public bool dailyEmailLimit;
      public bool emailOptOutDate;
      public bool partnerEmailOptInDate;
      public bool preferredLanguage;
      public bool preferredCountry;
      public bool clipFullPage;
      public bool twitterUserName;
      public bool twitterId;
      public bool groupName;
      public bool recognitionLanguage;
      public bool referralProof;
      public bool educationalDiscount;
      public bool businessAddress;
      public bool hideSponsorBilling;
      public bool taxExempt;
      public bool useEmailAutoFiling;
      public bool reminderEmailConfig;
    }

    public UserAttributes() {
    }

    public void Read (TProtocol iprot)
    {
      TField field;
      iprot.ReadStructBegin();
      while (true)
      {
        field = iprot.ReadFieldBegin();
        if (field.Type == TType.Stop) { 
          break;
        }
        switch (field.ID)
        {
          case 1:
            if (field.Type == TType.String) {
              DefaultLocationName = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.Double) {
              DefaultLatitude = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.Double) {
              DefaultLongitude = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.Bool) {
              Preactivation = iprot.ReadBool();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 5:
            if (field.Type == TType.List) {
              {
                ViewedPromotions = new List<string>();
                TList _list0 = iprot.ReadListBegin();
                for( int _i1 = 0; _i1 < _list0.Count; ++_i1)
                {
                  string _elem2 = null;
                  _elem2 = iprot.ReadString();
                  ViewedPromotions.Add(_elem2);
                }
                iprot.ReadListEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 6:
            if (field.Type == TType.String) {
              IncomingEmailAddress = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 7:
            if (field.Type == TType.List) {
              {
                RecentMailedAddresses = new List<string>();
                TList _list3 = iprot.ReadListBegin();
                for( int _i4 = 0; _i4 < _list3.Count; ++_i4)
                {
                  string _elem5 = null;
                  _elem5 = iprot.ReadString();
                  RecentMailedAddresses.Add(_elem5);
                }
                iprot.ReadListEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 9:
            if (field.Type == TType.String) {
              Comments = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 11:
            if (field.Type == TType.I64) {
              DateAgreedToTermsOfService = iprot.ReadI64();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 12:
            if (field.Type == TType.I32) {
              MaxReferrals = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 13:
            if (field.Type == TType.I32) {
              ReferralCount = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 14:
            if (field.Type == TType.String) {
              RefererCode = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 15:
            if (field.Type == TType.I64) {
              SentEmailDate = iprot.ReadI64();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 16:
            if (field.Type == TType.I32) {
              SentEmailCount = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 17:
            if (field.Type == TType.I32) {
              DailyEmailLimit = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 18:
            if (field.Type == TType.I64) {
              EmailOptOutDate = iprot.ReadI64();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 19:
            if (field.Type == TType.I64) {
              PartnerEmailOptInDate = iprot.ReadI64();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 20:
            if (field.Type == TType.String) {
              PreferredLanguage = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 21:
            if (field.Type == TType.String) {
              PreferredCountry = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 22:
            if (field.Type == TType.Bool) {
              ClipFullPage = iprot.ReadBool();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 23:
            if (field.Type == TType.String) {
              TwitterUserName = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 24:
            if (field.Type == TType.String) {
              TwitterId = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 25:
            if (field.Type == TType.String) {
              GroupName = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 26:
            if (field.Type == TType.String) {
              RecognitionLanguage = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 28:
            if (field.Type == TType.String) {
              ReferralProof = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 29:
            if (field.Type == TType.Bool) {
              EducationalDiscount = iprot.ReadBool();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 30:
            if (field.Type == TType.String) {
              BusinessAddress = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 31:
            if (field.Type == TType.Bool) {
              HideSponsorBilling = iprot.ReadBool();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 32:
            if (field.Type == TType.Bool) {
              TaxExempt = iprot.ReadBool();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 33:
            if (field.Type == TType.Bool) {
              UseEmailAutoFiling = iprot.ReadBool();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 34:
            if (field.Type == TType.I32) {
              ReminderEmailConfig = (ReminderEmailConfig)iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          default: 
            TProtocolUtil.Skip(iprot, field.Type);
            break;
        }
        iprot.ReadFieldEnd();
      }
      iprot.ReadStructEnd();
    }

    public void Write(TProtocol oprot) {
      TStruct struc = new TStruct("UserAttributes");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (DefaultLocationName != null && __isset.defaultLocationName) {
        field.Name = "defaultLocationName";
        field.Type = TType.String;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(DefaultLocationName);
        oprot.WriteFieldEnd();
      }
      if (__isset.defaultLatitude) {
        field.Name = "defaultLatitude";
        field.Type = TType.Double;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(DefaultLatitude);
        oprot.WriteFieldEnd();
      }
      if (__isset.defaultLongitude) {
        field.Name = "defaultLongitude";
        field.Type = TType.Double;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(DefaultLongitude);
        oprot.WriteFieldEnd();
      }
      if (__isset.preactivation) {
        field.Name = "preactivation";
        field.Type = TType.Bool;
        field.ID = 4;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(Preactivation);
        oprot.WriteFieldEnd();
      }
      if (ViewedPromotions != null && __isset.viewedPromotions) {
        field.Name = "viewedPromotions";
        field.Type = TType.List;
        field.ID = 5;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.String, ViewedPromotions.Count));
          foreach (string _iter6 in ViewedPromotions)
          {
            oprot.WriteString(_iter6);
            oprot.WriteListEnd();
          }
        }
        oprot.WriteFieldEnd();
      }
      if (IncomingEmailAddress != null && __isset.incomingEmailAddress) {
        field.Name = "incomingEmailAddress";
        field.Type = TType.String;
        field.ID = 6;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(IncomingEmailAddress);
        oprot.WriteFieldEnd();
      }
      if (RecentMailedAddresses != null && __isset.recentMailedAddresses) {
        field.Name = "recentMailedAddresses";
        field.Type = TType.List;
        field.ID = 7;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.String, RecentMailedAddresses.Count));
          foreach (string _iter7 in RecentMailedAddresses)
          {
            oprot.WriteString(_iter7);
            oprot.WriteListEnd();
          }
        }
        oprot.WriteFieldEnd();
      }
      if (Comments != null && __isset.comments) {
        field.Name = "comments";
        field.Type = TType.String;
        field.ID = 9;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Comments);
        oprot.WriteFieldEnd();
      }
      if (__isset.dateAgreedToTermsOfService) {
        field.Name = "dateAgreedToTermsOfService";
        field.Type = TType.I64;
        field.ID = 11;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(DateAgreedToTermsOfService);
        oprot.WriteFieldEnd();
      }
      if (__isset.maxReferrals) {
        field.Name = "maxReferrals";
        field.Type = TType.I32;
        field.ID = 12;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(MaxReferrals);
        oprot.WriteFieldEnd();
      }
      if (__isset.referralCount) {
        field.Name = "referralCount";
        field.Type = TType.I32;
        field.ID = 13;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(ReferralCount);
        oprot.WriteFieldEnd();
      }
      if (RefererCode != null && __isset.refererCode) {
        field.Name = "refererCode";
        field.Type = TType.String;
        field.ID = 14;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(RefererCode);
        oprot.WriteFieldEnd();
      }
      if (__isset.sentEmailDate) {
        field.Name = "sentEmailDate";
        field.Type = TType.I64;
        field.ID = 15;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(SentEmailDate);
        oprot.WriteFieldEnd();
      }
      if (__isset.sentEmailCount) {
        field.Name = "sentEmailCount";
        field.Type = TType.I32;
        field.ID = 16;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(SentEmailCount);
        oprot.WriteFieldEnd();
      }
      if (__isset.dailyEmailLimit) {
        field.Name = "dailyEmailLimit";
        field.Type = TType.I32;
        field.ID = 17;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(DailyEmailLimit);
        oprot.WriteFieldEnd();
      }
      if (__isset.emailOptOutDate) {
        field.Name = "emailOptOutDate";
        field.Type = TType.I64;
        field.ID = 18;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(EmailOptOutDate);
        oprot.WriteFieldEnd();
      }
      if (__isset.partnerEmailOptInDate) {
        field.Name = "partnerEmailOptInDate";
        field.Type = TType.I64;
        field.ID = 19;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(PartnerEmailOptInDate);
        oprot.WriteFieldEnd();
      }
      if (PreferredLanguage != null && __isset.preferredLanguage) {
        field.Name = "preferredLanguage";
        field.Type = TType.String;
        field.ID = 20;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(PreferredLanguage);
        oprot.WriteFieldEnd();
      }
      if (PreferredCountry != null && __isset.preferredCountry) {
        field.Name = "preferredCountry";
        field.Type = TType.String;
        field.ID = 21;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(PreferredCountry);
        oprot.WriteFieldEnd();
      }
      if (__isset.clipFullPage) {
        field.Name = "clipFullPage";
        field.Type = TType.Bool;
        field.ID = 22;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(ClipFullPage);
        oprot.WriteFieldEnd();
      }
      if (TwitterUserName != null && __isset.twitterUserName) {
        field.Name = "twitterUserName";
        field.Type = TType.String;
        field.ID = 23;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(TwitterUserName);
        oprot.WriteFieldEnd();
      }
      if (TwitterId != null && __isset.twitterId) {
        field.Name = "twitterId";
        field.Type = TType.String;
        field.ID = 24;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(TwitterId);
        oprot.WriteFieldEnd();
      }
      if (GroupName != null && __isset.groupName) {
        field.Name = "groupName";
        field.Type = TType.String;
        field.ID = 25;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(GroupName);
        oprot.WriteFieldEnd();
      }
      if (RecognitionLanguage != null && __isset.recognitionLanguage) {
        field.Name = "recognitionLanguage";
        field.Type = TType.String;
        field.ID = 26;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(RecognitionLanguage);
        oprot.WriteFieldEnd();
      }
      if (ReferralProof != null && __isset.referralProof) {
        field.Name = "referralProof";
        field.Type = TType.String;
        field.ID = 28;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(ReferralProof);
        oprot.WriteFieldEnd();
      }
      if (__isset.educationalDiscount) {
        field.Name = "educationalDiscount";
        field.Type = TType.Bool;
        field.ID = 29;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(EducationalDiscount);
        oprot.WriteFieldEnd();
      }
      if (BusinessAddress != null && __isset.businessAddress) {
        field.Name = "businessAddress";
        field.Type = TType.String;
        field.ID = 30;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(BusinessAddress);
        oprot.WriteFieldEnd();
      }
      if (__isset.hideSponsorBilling) {
        field.Name = "hideSponsorBilling";
        field.Type = TType.Bool;
        field.ID = 31;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(HideSponsorBilling);
        oprot.WriteFieldEnd();
      }
      if (__isset.taxExempt) {
        field.Name = "taxExempt";
        field.Type = TType.Bool;
        field.ID = 32;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(TaxExempt);
        oprot.WriteFieldEnd();
      }
      if (__isset.useEmailAutoFiling) {
        field.Name = "useEmailAutoFiling";
        field.Type = TType.Bool;
        field.ID = 33;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(UseEmailAutoFiling);
        oprot.WriteFieldEnd();
      }
      if (__isset.reminderEmailConfig) {
        field.Name = "reminderEmailConfig";
        field.Type = TType.I32;
        field.ID = 34;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32((int)ReminderEmailConfig);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("UserAttributes(");
      sb.Append("DefaultLocationName: ");
      sb.Append(DefaultLocationName);
      sb.Append(",DefaultLatitude: ");
      sb.Append(DefaultLatitude);
      sb.Append(",DefaultLongitude: ");
      sb.Append(DefaultLongitude);
      sb.Append(",Preactivation: ");
      sb.Append(Preactivation);
      sb.Append(",ViewedPromotions: ");
      sb.Append(ViewedPromotions);
      sb.Append(",IncomingEmailAddress: ");
      sb.Append(IncomingEmailAddress);
      sb.Append(",RecentMailedAddresses: ");
      sb.Append(RecentMailedAddresses);
      sb.Append(",Comments: ");
      sb.Append(Comments);
      sb.Append(",DateAgreedToTermsOfService: ");
      sb.Append(DateAgreedToTermsOfService);
      sb.Append(",MaxReferrals: ");
      sb.Append(MaxReferrals);
      sb.Append(",ReferralCount: ");
      sb.Append(ReferralCount);
      sb.Append(",RefererCode: ");
      sb.Append(RefererCode);
      sb.Append(",SentEmailDate: ");
      sb.Append(SentEmailDate);
      sb.Append(",SentEmailCount: ");
      sb.Append(SentEmailCount);
      sb.Append(",DailyEmailLimit: ");
      sb.Append(DailyEmailLimit);
      sb.Append(",EmailOptOutDate: ");
      sb.Append(EmailOptOutDate);
      sb.Append(",PartnerEmailOptInDate: ");
      sb.Append(PartnerEmailOptInDate);
      sb.Append(",PreferredLanguage: ");
      sb.Append(PreferredLanguage);
      sb.Append(",PreferredCountry: ");
      sb.Append(PreferredCountry);
      sb.Append(",ClipFullPage: ");
      sb.Append(ClipFullPage);
      sb.Append(",TwitterUserName: ");
      sb.Append(TwitterUserName);
      sb.Append(",TwitterId: ");
      sb.Append(TwitterId);
      sb.Append(",GroupName: ");
      sb.Append(GroupName);
      sb.Append(",RecognitionLanguage: ");
      sb.Append(RecognitionLanguage);
      sb.Append(",ReferralProof: ");
      sb.Append(ReferralProof);
      sb.Append(",EducationalDiscount: ");
      sb.Append(EducationalDiscount);
      sb.Append(",BusinessAddress: ");
      sb.Append(BusinessAddress);
      sb.Append(",HideSponsorBilling: ");
      sb.Append(HideSponsorBilling);
      sb.Append(",TaxExempt: ");
      sb.Append(TaxExempt);
      sb.Append(",UseEmailAutoFiling: ");
      sb.Append(UseEmailAutoFiling);
      sb.Append(",ReminderEmailConfig: ");
      sb.Append(ReminderEmailConfig);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
