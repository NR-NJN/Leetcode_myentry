/**
 * Note: The returned array must be malloced, assume caller calls free().
 */
char ** wordSubsets(char ** words1, int words1Size, char ** words2, int words2Size, int* returnSize){

    
    int hash1[26];
    int hash2[26];
    int temp[26];
    char **ans=(char**)malloc(sizeof(char*)*words1Size);
    char *w;                                               
    int count;
    *returnSize=0;
    
    for(int i=0; i<26; i++){
        hash1[i]=0;
    }                                                                   
    for(int i=0; i<words2Size; i++){
        memset((void*)temp, 0, sizeof(temp));
        
        for(w=words2[i]; *w; w++){
            temp[*w-'a']++;
        }
        for(int j=0; j<26; j++){
            if (temp[j]>hash1[j]){
                hash1[j]=temp[j];
        }
    }
    
}

    for(int i=0;i<words1Size; i++){
        memcpy((void *)hash2, (void *)hash1, sizeof(hash1));
        
        for (w= words1[i]; *w; w++){
            hash2[*w-'a']--;
        }
        count=0;
        for(int j =0; j<26; j++){
            if (hash2[j]>0){
                break;
            }
            count++;        
        }
    
        if(count==26){
            ans[*returnSize]=words1[i];
            (*returnSize)++;
        }
    }
    if (*returnSize==0){
        free(ans);
        ans=NULL;
    }

return ans;
}