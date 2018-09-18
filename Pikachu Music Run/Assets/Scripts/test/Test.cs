using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Token: 0x06000002 RID: 2 RVA: 0x0000214C File Offset: 0x0000034C
    private void Start()
    {
        this.cubes.Add(this.cube01);
        this.cubes.Add(this.cube02);
        this.cubes.Add(this.cube03);
        this.cubes.Add(this.cube04);
        this.cubes.Add(this.cube05);
        this.cubes.Add(this.cube06);
        this.cubes.Add(this.cube07);
        this.cubes.Add(this.cube08);
        this.cubes.Add(this.cube09);
        this.cubes.Add(this.cube10);
        this.cubes.Add(this.cube11);
        this.cubes.Add(this.cube12);
        this.cubes.Add(this.cube13);
        this.cubes.Add(this.cube14);
        this.cubes.Add(this.cube15);
        this.cubes.Add(this.cube16);
        this.cubes.Add(this.cube17);
        this.cubes.Add(this.cube18);
        this.cubes.Add(this.cube19);
        this.cubes.Add(this.cube20);
        this.cubes.Add(this.cube21);
        this.cubes.Add(this.cube22);
        this.cubes.Add(this.cube23);
        this.cubes.Add(this.cube24);
        this.cubes.Add(this.cube25);
        this.cubes.Add(this.cube26);
        this.cubes.Add(this.cube27);
        this.cubes.Add(this.cube28);
        this.cubes.Add(this.cube29);
        this.cubes.Add(this.cube30);
        this.cubes.Add(this.cube31);
        this.cubes.Add(this.cube32);
        this.cubes.Add(this.cube33);
        this.cubes.Add(this.cube34);
        this.cubes.Add(this.cube35);
        this.cubes.Add(this.cube36);
        this.cubes.Add(this.cube37);
        this.cubes.Add(this.cube38);
        this.cubes.Add(this.cube39);
        this.cubes.Add(this.cube40);
        this.cubes.Add(this.cube41);
        this.cubes.Add(this.cube42);
        this.cubes.Add(this.cube43);
        this.cubes.Add(this.cube44);
        this.cubes.Add(this.cube45);
        this.cubes.Add(this.cube46);
        this.cubes.Add(this.cube47);
        this.cubes.Add(this.cube48);
        this.cubes.Add(this.cube49);
        this.cubes.Add(this.cube50);
        this.cubes.Add(this.cube51);
        this.cubes.Add(this.cube52);
        this.specmags.Add(this.specMag01);
        this.specmags.Add(this.specMag02);
        this.specmags.Add(this.specMag03);
        this.specmags.Add(this.specMag04);
        this.specmags.Add(this.specMag05);
        this.specmags.Add(this.specMag06);
        this.specmags.Add(this.specMag07);
        this.specmags.Add(this.specMag08);
        this.specmags.Add(this.specMag09);
        this.specmags.Add(this.specMag10);
        this.specmags.Add(this.specMag11);
        this.specmags.Add(this.specMag12);
        this.specmags.Add(this.specMag13);
        this.specmags.Add(this.specMag14);
        this.specmags.Add(this.specMag15);
        this.specmags.Add(this.specMag16);
        this.specmags.Add(this.specMag17);
        this.specmags.Add(this.specMag18);
        this.specmags.Add(this.specMag19);
        this.specmags.Add(this.specMag20);
        this.specmags.Add(this.specMag21);
        this.specmags.Add(this.specMag22);
        this.specmags.Add(this.specMag23);
        this.specmags.Add(this.specMag24);
        this.specmags.Add(this.specMag25);
        this.specmags.Add(this.specMag26);
        this.specmags.Add(this.specMag27);
        this.specmags.Add(this.specMag28);
        this.specmags.Add(this.specMag29);
        this.specmags.Add(this.specMag30);
        this.specmags.Add(this.specMag31);
        this.specmags.Add(this.specMag32);
        this.specmags.Add(this.specMag33);
        this.specmags.Add(this.specMag34);
        this.specmags.Add(this.specMag35);
        this.specmags.Add(this.specMag36);
        this.specmags.Add(this.specMag37);
        this.specmags.Add(this.specMag38);
        this.specmags.Add(this.specMag39);
        this.specmags.Add(this.specMag40);
        this.specmags.Add(this.specMag41);
        this.specmags.Add(this.specMag42);
        this.specmags.Add(this.specMag43);
        this.specmags.Add(this.specMag44);
        this.specmags.Add(this.specMag45);
        this.specmags.Add(this.specMag46);
        this.specmags.Add(this.specMag47);
        this.specmags.Add(this.specMag48);
        this.specmags.Add(this.specMag49);
        this.specmags.Add(this.specMag50);
        this.specmags.Add(this.specMag51);
        this.specmags.Add(this.specMag52);
    }

    // Token: 0x06000003 RID: 3 RVA: 0x00002844 File Offset: 0x00000A44
    private void music()
    {
        base.GetComponent<AudioSource>().Play();
    }

    // Token: 0x06000004 RID: 4 RVA: 0x00002854 File Offset: 0x00000A54
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        this.spec = AudioListener.GetSpectrumData(8192, 0, FFTWindow.BlackmanHarris);
        this.specmags[13] = this.spec[1] + this.spec[2] + this.spec[3] + this.spec[4] + this.spec[5] + this.spec[6] + this.spec[7] + this.spec[8] + this.spec[9] + this.spec[10] + this.spec[11] + this.spec[12] + this.spec[13] + this.spec[14];
        this.specmags[14] = this.spec[15] + this.spec[15];
        this.specmags[15] = this.spec[16] + this.spec[17];
        this.specmags[16] = this.spec[18] + this.spec[18];
        this.specmags[17] = this.spec[19] + this.spec[20];
        this.specmags[18] = this.spec[21] + this.spec[21];
        this.specmags[19] = this.spec[22] + this.spec[23];
        this.specmags[20] = this.spec[24] + this.spec[25] + this.spec[26];
        this.specmags[21] = this.spec[27] + this.spec[28] + this.spec[29];
        this.specmags[22] = this.spec[30] + this.spec[31] + this.spec[32];
        this.specmags[23] = this.spec[33] + this.spec[34] + this.spec[35];
        this.specmags[24] = this.spec[36] + this.spec[37] + this.spec[38];
        this.specmags[25] = this.spec[39] + this.spec[40] + this.spec[40];
        this.specmags[26] = this.spec[41] + this.spec[42] + this.spec[43];
        this.specmags[27] = this.spec[44] + this.spec[45] + this.spec[46];
        this.specmags[28] = this.spec[48] + this.spec[49] + this.spec[50] + this.spec[51] + this.spec[52] + this.spec[53];
        this.specmags[29] = this.spec[54] + this.spec[55] + this.spec[56] + this.spec[57] + this.spec[58] + this.spec[59];
        this.specmags[30] = this.spec[60] + this.spec[61] + this.spec[62] + this.spec[63] + this.spec[64] + this.spec[64];
        this.specmags[31] = this.spec[65] + this.spec[66] + this.spec[67] + this.spec[68] + this.spec[69] + this.spec[70];
        this.specmags[32] = this.spec[71] + this.spec[72] + this.spec[73] + this.spec[74] + this.spec[75] + this.spec[76];
        this.specmags[33] = this.spec[77] + this.spec[78] + this.spec[79] + this.spec[80] + this.spec[81] + this.spec[82];
        this.specmags[34] = this.spec[83] + this.spec[84] + this.spec[85] + this.spec[86] + this.spec[87] + this.spec[88];
        this.specmags[35] = this.spec[89] + this.spec[90] + this.spec[91] + this.spec[92] + this.spec[93] + this.spec[94];
        this.specmags[36] = this.spec[95] + this.spec[96] + this.spec[97] + this.spec[98] + this.spec[99] + this.spec[100] + this.spec[101] + this.spec[102] + this.spec[103] + this.spec[104];
        this.specmags[37] = this.spec[105] + this.spec[106] + this.spec[107] + this.spec[108] + this.spec[109] + this.spec[110] + this.spec[111] + this.spec[113] + this.spec[114] + this.spec[115];
        this.specmags[38] = this.spec[116] + this.spec[117] + this.spec[118] + this.spec[119] + this.spec[120] + this.spec[121] + this.spec[122] + this.spec[123] + this.spec[124] + this.spec[125];
        this.specmags[39] = this.spec[126] + this.spec[127] + this.spec[128] + this.spec[129] + this.spec[130] + this.spec[131] + this.spec[132] + this.spec[133] + this.spec[134] + this.spec[135];
        this.specmags[40] = this.spec[136] + this.spec[137] + this.spec[138] + this.spec[139] + this.spec[140] + this.spec[141] + this.spec[142] + this.spec[143] + this.spec[144] + this.spec[145];
        this.specmags[41] = this.spec[146] + this.spec[147] + this.spec[148] + this.spec[149] + this.spec[150] + this.spec[151] + this.spec[152] + this.spec[153] + this.spec[154] + this.spec[155];
        this.specmags[42] = this.spec[156] + this.spec[157] + this.spec[158] + this.spec[159] + this.spec[160] + this.spec[161] + this.spec[162] + this.spec[163] + this.spec[164] + this.spec[165];
        this.specmags[43] = this.spec[166] + this.spec[167] + this.spec[168] + this.spec[169] + this.spec[170] + this.spec[171] + this.spec[172] + this.spec[173] + this.spec[174] + this.spec[175];
        this.specmags[44] = this.spec[176] + this.spec[177] + this.spec[178] + this.spec[179] + this.spec[180] + this.spec[181] + this.spec[182] + this.spec[183] + this.spec[184] + this.spec[185];
        this.specmags[45] = this.spec[186] + this.spec[187] + this.spec[188] + this.spec[189] + this.spec[190] + this.spec[191] + this.spec[192] + this.spec[193] + this.spec[194] + this.spec[195];
        this.specmags[46] = this.spec[196] + this.spec[197] + this.spec[198] + this.spec[199] + this.spec[200] + this.spec[201] + this.spec[202] + this.spec[203] + this.spec[204] + this.spec[205];
        this.specmags[47] = this.spec[206] + this.spec[207] + this.spec[208] + this.spec[209] + this.spec[210] + this.spec[211] + this.spec[212] + this.spec[213] + this.spec[214] + this.spec[215];
        this.specmags[48] = this.spec[216] + this.spec[217] + this.spec[218] + this.spec[219] + this.spec[220] + this.spec[221] + this.spec[222] + this.spec[223] + this.spec[224] + this.spec[225];
        this.specmags[49] = this.spec[226] + this.spec[227] + this.spec[228] + this.spec[229] + this.spec[230] + this.spec[231] + this.spec[232] + this.spec[233] + this.spec[234] + this.spec[235];
        this.specmags[50] = this.spec[236] + this.spec[237] + this.spec[238] + this.spec[239] + this.spec[240] + this.spec[241] + this.spec[242] + this.spec[243] + this.spec[244] + this.spec[245];
        this.specmags[51] = this.spec[246] + this.spec[247] + this.spec[248] + this.spec[249] + this.spec[250] + this.spec[251] + this.spec[252] + this.spec[253] + this.spec[254] + this.spec[255];
        this.specmags[0] = this.spec[256] + this.spec[257] + this.spec[258] + this.spec[259] + this.spec[260] + this.spec[261] + this.spec[262] + this.spec[263] + this.spec[264] + this.spec[265] + this.spec[266] + this.spec[267] + this.spec[268] + this.spec[269] + this.spec[270] + this.spec[271] + this.spec[272] + this.spec[273] + this.spec[274] + this.spec[275];
        this.specmags[1] = this.spec[276] + this.spec[278] + this.spec[279] + this.spec[280] + this.spec[281] + this.spec[282] + this.spec[283] + this.spec[284] + this.spec[285] + this.spec[286] + this.spec[287] + this.spec[288] + this.spec[289] + this.spec[290] + this.spec[291] + this.spec[292] + this.spec[293] + this.spec[294] + this.spec[295] + this.spec[296];
        this.specmags[2] = this.spec[297] + this.spec[298] + this.spec[299] + this.spec[300] + this.spec[301] + this.spec[302] + this.spec[303] + this.spec[304] + this.spec[305] + this.spec[306] + this.spec[307] + this.spec[308] + this.spec[309] + this.spec[310] + this.spec[311] + this.spec[312] + this.spec[313] + this.spec[314] + this.spec[315] + this.spec[316];
        this.specmags[3] = this.spec[317] + this.spec[318] + this.spec[319] + this.spec[320] + this.spec[321] + this.spec[322] + this.spec[323] + this.spec[324] + this.spec[325] + this.spec[326] + this.spec[327] + this.spec[328] + this.spec[329] + this.spec[330] + this.spec[331] + this.spec[332] + this.spec[333] + this.spec[334] + this.spec[335] + this.spec[336];
        this.specmags[4] = this.spec[337] + this.spec[338] + this.spec[339] + this.spec[340] + this.spec[341] + this.spec[342] + this.spec[343] + this.spec[344] + this.spec[345] + this.spec[346] + this.spec[347] + this.spec[348] + this.spec[349] + this.spec[350] + this.spec[351] + this.spec[352] + this.spec[353] + this.spec[354] + this.spec[355] + this.spec[356];
        this.specmags[5] = this.spec[357] + this.spec[358] + this.spec[359] + this.spec[360] + this.spec[361] + this.spec[362] + this.spec[363] + this.spec[364] + this.spec[365] + this.spec[366] + this.spec[367] + this.spec[368] + this.spec[369] + this.spec[370] + this.spec[371] + this.spec[372] + this.spec[373] + this.spec[374] + this.spec[375] + this.spec[376];
        this.specmags[6] = this.spec[377] + this.spec[378] + this.spec[379] + this.spec[380] + this.spec[381] + this.spec[382] + this.spec[262] + this.spec[384] + this.spec[385] + this.spec[386] + this.spec[387] + this.spec[388] + this.spec[389] + this.spec[390] + this.spec[391] + this.spec[392] + this.spec[272] + this.spec[394] + this.spec[395] + this.spec[396];
        this.specmags[7] = this.spec[397] + this.spec[398] + this.spec[399] + this.spec[400] + this.spec[401] + this.spec[402] + this.spec[262] + this.spec[404] + this.spec[405] + this.spec[406] + this.spec[407] + this.spec[408] + this.spec[409] + this.spec[410] + this.spec[411] + this.spec[412] + this.spec[272] + this.spec[414] + this.spec[415] + this.spec[416];
        this.specmags[8] = this.spec[417] + this.spec[418] + this.spec[419] + this.spec[420] + this.spec[421] + this.spec[422] + this.spec[262] + this.spec[424] + this.spec[425] + this.spec[426] + this.spec[427] + this.spec[428] + this.spec[429] + this.spec[430] + this.spec[431] + this.spec[432] + this.spec[272] + this.spec[434] + this.spec[435] + this.spec[436];
        this.specmags[9] = this.spec[437] + this.spec[438] + this.spec[439] + this.spec[440] + this.spec[441] + this.spec[442] + this.spec[262] + this.spec[444] + this.spec[445] + this.spec[446] + this.spec[447] + this.spec[448] + this.spec[449] + this.spec[450] + this.spec[451] + this.spec[452] + this.spec[272] + this.spec[454] + this.spec[455] + this.spec[456];
        this.specmags[10] = this.spec[457] + this.spec[458] + this.spec[459] + this.spec[460] + this.spec[461] + this.spec[462] + this.spec[262] + this.spec[464] + this.spec[465] + this.spec[466] + this.spec[467] + this.spec[468] + this.spec[469] + this.spec[470] + this.spec[471] + this.spec[472] + this.spec[272] + this.spec[474] + this.spec[475] + this.spec[476];
        this.specmags[11] = this.spec[477] + this.spec[478] + this.spec[479] + this.spec[480] + this.spec[481] + this.spec[482] + this.spec[262] + this.spec[484] + this.spec[486] + this.spec[486] + this.spec[487] + this.spec[488] + this.spec[489] + this.spec[490] + this.spec[491] + this.spec[492] + this.spec[272] + this.spec[494] + this.spec[495] + this.spec[496];
        this.specmags[12] = this.spec[497] + this.spec[498] + this.spec[499] + this.spec[500] + this.spec[501] + this.spec[502] + this.spec[262] + this.spec[504] + this.spec[505] + this.spec[506] + this.spec[507] + this.spec[508] + this.spec[509] + this.spec[510] + this.spec[511] + this.spec[512] + this.spec[513] + this.spec[514] + this.spec[515] + this.spec[516];
        for (int i = 0; i <= 51; i++)
        {
            this.cubes[i].gameObject.transform.localScale = new Vector3(1f, this.specmags[i] * this.intensity, 1f);
            if (this.cubes[i].gameObject.transform.localScale.y >= (float)this.limit)
            {
                this.cubes[i].gameObject.transform.localScale = new Vector3(1f, (float)this.limit, 1f);
            }
        }
    }

    // Token: 0x04000001 RID: 1
    public GameObject cube01;

    // Token: 0x04000002 RID: 2
    public GameObject cube02;

    // Token: 0x04000003 RID: 3
    public GameObject cube03;

    // Token: 0x04000004 RID: 4
    public GameObject cube04;

    // Token: 0x04000005 RID: 5
    public GameObject cube05;

    // Token: 0x04000006 RID: 6
    public GameObject cube06;

    // Token: 0x04000007 RID: 7
    public GameObject cube07;

    // Token: 0x04000008 RID: 8
    public GameObject cube08;

    // Token: 0x04000009 RID: 9
    public GameObject cube09;

    // Token: 0x0400000A RID: 10
    public GameObject cube10;

    // Token: 0x0400000B RID: 11
    public GameObject cube11;

    // Token: 0x0400000C RID: 12
    public GameObject cube12;

    // Token: 0x0400000D RID: 13
    public GameObject cube13;

    // Token: 0x0400000E RID: 14
    public GameObject cube14;

    // Token: 0x0400000F RID: 15
    public GameObject cube15;

    // Token: 0x04000010 RID: 16
    public GameObject cube16;

    // Token: 0x04000011 RID: 17
    public GameObject cube17;

    // Token: 0x04000012 RID: 18
    public GameObject cube18;

    // Token: 0x04000013 RID: 19
    public GameObject cube19;

    // Token: 0x04000014 RID: 20
    public GameObject cube20;

    // Token: 0x04000015 RID: 21
    public GameObject cube21;

    // Token: 0x04000016 RID: 22
    public GameObject cube22;

    // Token: 0x04000017 RID: 23
    public GameObject cube23;

    // Token: 0x04000018 RID: 24
    public GameObject cube24;

    // Token: 0x04000019 RID: 25
    public GameObject cube25;

    // Token: 0x0400001A RID: 26
    public GameObject cube26;

    // Token: 0x0400001B RID: 27
    public GameObject cube27;

    // Token: 0x0400001C RID: 28
    public GameObject cube28;

    // Token: 0x0400001D RID: 29
    public GameObject cube29;

    // Token: 0x0400001E RID: 30
    public GameObject cube30;

    // Token: 0x0400001F RID: 31
    public GameObject cube31;

    // Token: 0x04000020 RID: 32
    public GameObject cube32;

    // Token: 0x04000021 RID: 33
    public GameObject cube33;

    // Token: 0x04000022 RID: 34
    public GameObject cube34;

    // Token: 0x04000023 RID: 35
    public GameObject cube35;

    // Token: 0x04000024 RID: 36
    public GameObject cube36;

    // Token: 0x04000025 RID: 37
    public GameObject cube37;

    // Token: 0x04000026 RID: 38
    public GameObject cube38;

    // Token: 0x04000027 RID: 39
    public GameObject cube39;

    // Token: 0x04000028 RID: 40
    public GameObject cube40;

    // Token: 0x04000029 RID: 41
    public GameObject cube41;

    // Token: 0x0400002A RID: 42
    public GameObject cube42;

    // Token: 0x0400002B RID: 43
    public GameObject cube43;

    // Token: 0x0400002C RID: 44
    public GameObject cube44;

    // Token: 0x0400002D RID: 45
    public GameObject cube45;

    // Token: 0x0400002E RID: 46
    public GameObject cube46;

    // Token: 0x0400002F RID: 47
    public GameObject cube47;

    // Token: 0x04000030 RID: 48
    public GameObject cube48;

    // Token: 0x04000031 RID: 49
    public GameObject cube49;

    // Token: 0x04000032 RID: 50
    public GameObject cube50;

    // Token: 0x04000033 RID: 51
    public GameObject cube51;

    // Token: 0x04000034 RID: 52
    public GameObject cube52;

    // Token: 0x04000035 RID: 53
    public float specMag01;

    // Token: 0x04000036 RID: 54
    public float specMag02;

    // Token: 0x04000037 RID: 55
    public float specMag03;

    // Token: 0x04000038 RID: 56
    public float specMag04;

    // Token: 0x04000039 RID: 57
    public float specMag05;

    // Token: 0x0400003A RID: 58
    public float specMag06;

    // Token: 0x0400003B RID: 59
    public float specMag07;

    // Token: 0x0400003C RID: 60
    public float specMag08;

    // Token: 0x0400003D RID: 61
    public float specMag09;

    // Token: 0x0400003E RID: 62
    public float specMag10;

    // Token: 0x0400003F RID: 63
    public float specMag11;

    // Token: 0x04000040 RID: 64
    public float specMag12;

    // Token: 0x04000041 RID: 65
    public float specMag13;

    // Token: 0x04000042 RID: 66
    public float specMag14;

    // Token: 0x04000043 RID: 67
    public float specMag15;

    // Token: 0x04000044 RID: 68
    public float specMag16;

    // Token: 0x04000045 RID: 69
    public float specMag17;

    // Token: 0x04000046 RID: 70
    public float specMag18;

    // Token: 0x04000047 RID: 71
    public float specMag19;

    // Token: 0x04000048 RID: 72
    public float specMag20;

    // Token: 0x04000049 RID: 73
    public float specMag21;

    // Token: 0x0400004A RID: 74
    public float specMag22;

    // Token: 0x0400004B RID: 75
    public float specMag23;

    // Token: 0x0400004C RID: 76
    public float specMag24;

    // Token: 0x0400004D RID: 77
    public float specMag25;

    // Token: 0x0400004E RID: 78
    public float specMag26;

    // Token: 0x0400004F RID: 79
    public float specMag27;

    // Token: 0x04000050 RID: 80
    public float specMag28;

    // Token: 0x04000051 RID: 81
    public float specMag29;

    // Token: 0x04000052 RID: 82
    public float specMag30;

    // Token: 0x04000053 RID: 83
    public float specMag31;

    // Token: 0x04000054 RID: 84
    public float specMag32;

    // Token: 0x04000055 RID: 85
    public float specMag33;

    // Token: 0x04000056 RID: 86
    public float specMag34;

    // Token: 0x04000057 RID: 87
    public float specMag35;

    // Token: 0x04000058 RID: 88
    public float specMag36;

    // Token: 0x04000059 RID: 89
    public float specMag37;

    // Token: 0x0400005A RID: 90
    public float specMag38;

    // Token: 0x0400005B RID: 91
    public float specMag39;

    // Token: 0x0400005C RID: 92
    public float specMag40;

    // Token: 0x0400005D RID: 93
    public float specMag41;

    // Token: 0x0400005E RID: 94
    public float specMag42;

    // Token: 0x0400005F RID: 95
    public float specMag43;

    // Token: 0x04000060 RID: 96
    public float specMag44;

    // Token: 0x04000061 RID: 97
    public float specMag45;

    // Token: 0x04000062 RID: 98
    public float specMag46;

    // Token: 0x04000063 RID: 99
    public float specMag47;

    // Token: 0x04000064 RID: 100
    public float specMag48;

    // Token: 0x04000065 RID: 101
    public float specMag49;

    // Token: 0x04000066 RID: 102
    public float specMag50;

    // Token: 0x04000067 RID: 103
    public float specMag51;

    // Token: 0x04000068 RID: 104
    public float specMag52;

    // Token: 0x04000069 RID: 105
    public int limit = 50;

    // Token: 0x0400006A RID: 106
    public float intensity = 50f;

    // Token: 0x0400006B RID: 107
    public float rate = 10f;

    // Token: 0x0400006C RID: 108
    public float mytime = 1f;

    // Token: 0x0400006D RID: 109
    public bool waiting;

    // Token: 0x0400006E RID: 110
    public float speed = 0.1f;

    // Token: 0x0400006F RID: 111
    public float[] spec;

    // Token: 0x04000070 RID: 112
    private List<float> specmags = new List<float>();

    // Token: 0x04000071 RID: 113
    private List<GameObject> cubes = new List<GameObject>();

}
