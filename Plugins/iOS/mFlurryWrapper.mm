//
//  mFlurryWrapper.m
//
//
//  Created by PRADA Hsiung on 13/3/8.
//
//

#import "mFlurryWrapper.h"
#import "Flurry.h"

@implementation mFlurryWrapper

extern "C" {
    const void mStartSession(const char *apiKey){
        NSString *key=[NSString stringWithFormat:@"%s",apiKey];
        NSLog(key);
        [Flurry startSession:key];
    }
    
    
    const void mStopSession(){
        //    [Flurry stopSession];
    }
    
    const void mLogEvent(const char *msg){
        NSString *m=[NSString stringWithFormat:@"%s",msg];
        NSLog(m);
        [Flurry logEvent:m];
    }
}

@end
