# Case1
Bu program belirtilen koşullara göre en ucuz yöntemi seçmektedir.
Koşullar şu şekildedir:

1.) Tüm juriler suçsuz diyor:
allJuriesInnocent = totalJuryCount * 50

2.) Jurilerin en az yarısı suçsuz diyor, hakim ise kararsız:
juryInnocentJudgeUndecided = innocentJuryCount * 50 + judgeUndecided

3.) Hakim beraat ister:
judgePrice

Hakim kararsız değişkeni: judgeUndecided = judgePrice / 2
